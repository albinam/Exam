using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace ExamBusinessLogic.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        [DisplayName("ФИО")]
        public string FIO { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }
        [DisplayName("Место работы")]
        public string Work { get; set; }
        [DisplayName("Название статьи")]
        public string Name { get; set; }
    }
}
