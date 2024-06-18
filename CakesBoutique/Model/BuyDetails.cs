using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BuyDetails:BaseEntity
    {
        public int DetailsCode { get; set; }
        public Buying BuyingCode { get; set; }
        public CakeDesserts CakeCode { get; set; }
        public int Amount { get; set; }
        public Status StatusCode { get; set; }
        public override string GetTableName()
        {
            return "BuyDetails";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "DetailsCode" };
        }
    }
}
