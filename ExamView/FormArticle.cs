using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ExamView
{
    public partial class FormArticle : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IArticleLogic article;
        private int? id;
        public FormArticle(IArticleLogic article)
        {
            InitializeComponent();
            this.article = article;
        }
        private void FormArticle_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = article.Read(new ArticleBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Name;
                        textBoxSubject.Text = view.Theme;
                        dateTimePicker1.Value = view.DateCreate;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSubject.Text))
            {
                MessageBox.Show("Заполните тематику", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                article.CreateOrUpdate(new ArticleBindingModel
                {
                    Id = id,
                    Name = textBoxTitle.Text,
                    Theme = textBoxSubject.Text,
                    DateCreate = dateTimePicker1.Value
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}