﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_HomeAngularJS.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Forum> Forums { get; set; }

        //public Forum Forums { get; set; }
    }
}