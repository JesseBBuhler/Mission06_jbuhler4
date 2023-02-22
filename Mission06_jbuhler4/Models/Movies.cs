using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_jbuhler4.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage ="Title is a required field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is a required field")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Director is a required field")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Rating is a required field")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
        //build foreign key relationship
        [Required(ErrorMessage = "Category is a required field")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
