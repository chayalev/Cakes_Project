using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class CakeDesserts:BaseEntity
    {
        public int CakeCode { get; set; }
        public string CakeName { get; set; }
        public string CakeDetails { get; set; }
        public int CakePrice { get; set; }
        public CakesCategory CakeCategory { get; set; }
        public string CakePicture { get; set; }
        public bool IsDairy { get; set; }
        public override string GetTableName()
        {
            return "CakeDesserts";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "CakeCode" };
        }
    }
}
