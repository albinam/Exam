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
    public partial class FormAuthor : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IAuthorLogic author;

        private readonly IArticleLogic article;

        private int? id;

        public FormAuthor(IAuthorLogic service, IArticleLogic articleService)
        {
            InitializeComponent();
            this.author = service;
            this.article = articleService;
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            var list = article.Read(null);
            if (list != null)
            {
                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

            }
            if (id.HasValue)
            {
                try
                {

                    var view = author.Read(new AuthorBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFullName.Text = view.Name;
                        textBoxEmail.Text = view.Email;
                        dateTimePicker1.Value = view.Birthday;
                        textBoxJob.Text = view.Work;

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
            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите статью", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                author.CreateOrUpdate(new AuthorBindingModel
                {
                    Id = id,
                    FIO = textBoxFullName.Text,
                    Email = textBoxEmail.Text,
                    Work = textBoxJob.Text,
                    Birthday = dateTimePicker1.Value,
                    ArticleId = Convert.ToInt32(comboBox1.SelectedValue)
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