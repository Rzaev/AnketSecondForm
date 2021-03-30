﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketSecondForm
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birhday { get; set; }  

        public override string ToString()
        {
            return $"Name:{Name}\nSurname:{Surname}\nEmail:{Email}\nPhone:{Phone}\nBirthday:{Birhday}";
        }

    }
}
