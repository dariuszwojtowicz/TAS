﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwer.DTO
{
    public class PiwoDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Browarnia { get; set; }
        public double Price { get; set; }
        public double Power { get; set; }
        public string Genre { get; set; }
        public double Rate { get; set; }
    }
}