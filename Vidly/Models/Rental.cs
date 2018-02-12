﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Framework;

namespace Vidly.Models
{
    public class Rental
    {
        public long Id { get; set; }

        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned  { get; set; }

    }
}