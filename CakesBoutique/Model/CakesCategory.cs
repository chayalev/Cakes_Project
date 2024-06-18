﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class CakesCategory:BaseEntity
    {
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public override string GetTableName()
        {
            return "CakesCategory";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "CategoryCode" };
        }

    }
}