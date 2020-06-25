using System;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.BindingModels
{
    public class ArticleBindingModel
    {
           public int? Id { get; set;}
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime DateCreate { get; set; }
        public List<AuthorBindingModel> Authors { get; set; }
    }
}
