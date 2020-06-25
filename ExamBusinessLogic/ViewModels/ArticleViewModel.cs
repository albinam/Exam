using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExamBusinessLogic.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Тема")]
        public string Theme { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
    }
}
