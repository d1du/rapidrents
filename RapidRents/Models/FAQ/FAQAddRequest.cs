using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RapidRents.Web.Models.Requests.FAQ
{
    public class FAQAddRequest
    {
        [Required(ErrorMessage = "Question is required.")]
        [MinLength(10, ErrorMessage = "Questions must be at least 10 characters.")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Category is needed.")]
        [Range(1,4, ErrorMessage = "Please select a category.")]
        public int Category { get; set; }
        [Required(ErrorMessage = "Answer is required.")]
        [MinLength(3, ErrorMessage = "Please enter an answer with 3 or more characters.")]
        public string Answer { get; set; }
    }
}
