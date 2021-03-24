using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace joel_hilton_film_collection.Models
{
    public class MovieSubmissionResponse
    {
        [Key]
        public int SubmissionId { get; set; }
        [Required(ErrorMessage = "Please enter the Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter the Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter the Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please enter the Rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
