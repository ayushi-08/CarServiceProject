﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarProject.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}