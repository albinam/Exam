using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamDatabaseImplement.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}
