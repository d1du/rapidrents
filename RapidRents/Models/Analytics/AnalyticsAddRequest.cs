using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests.Analytics
{
    public class AnalyticsAddRequest
    {
        [Required(ErrorMessage = "URL is required.")]
        public string URL { get; set; }
        [Required(ErrorMessage = "TypeId is required.")]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }        
        public string Data { get; set; }
        public string[] DataArr { get; set; }
    }
}