﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCity
{
    public class GameCity
    {
        public GameCity() { }

        public ICollection Dict { get; set; }

        public void AddCity(string city)
        {
            Dict = new List<string> { city };
        }
    }
}