﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Sabio.Web.Models.Requests.Amenities;

namespace Sabio.Web.Models.Requests.Amenities
{
    public class AmenitiesUpdateRequest : AmenitiesAddRequest
    {
        [Required(ErrorMessage = "ID is required.")]
        public int Id { get; set; }
    }
}