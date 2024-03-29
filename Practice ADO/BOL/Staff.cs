﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Staff
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(18, 56)]
        public int Age { get; set; }

    }
}
