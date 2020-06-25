using System;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.BindingModels
{
    public class AuthorBindingModel
    {
        public int? Id { get; set; }
        public int ArticleId { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Work { get; set; }
    }
}
