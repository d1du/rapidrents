using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests.Amenities
{
    public class AmenitiesAddRequest
    {
        [Required(ErrorMessage = "Amenity name is required.")]
        [MinLength(3, ErrorMessage = "Name of amenity must be at least 3 characters.")]
        public string AmenityName { get; set; }
        [Required(ErrorMessage = "A boolean must be stated.")]
        public bool TypeId { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(3, ErrorMessage = "Please enter a description with 5 or more characters.")]
        public string Description { get; set; }
    }
}