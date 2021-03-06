﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidRents.Web.Models.Requests.FAQ;
using System.ComponentModel.DataAnnotations;

namespace RapidRents.Web.Models.Requests.FAQ
{
    public class FAQUpdateRequest : FAQAddRequest
    {
        [Required(ErrorMessage = "ID is required.")]
        public int Id { get; set; }

    }
}
