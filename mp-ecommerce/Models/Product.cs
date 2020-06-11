﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Url { get; set; }
    }
}