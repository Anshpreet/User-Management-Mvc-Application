﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
    }
}