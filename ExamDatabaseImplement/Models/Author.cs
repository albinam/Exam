using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamDatabaseImplement.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Work { get; set; }
        public virtual Article Article { get; set; }
    }
}
