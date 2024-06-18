using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Buying:BaseEntity
    {
        public int BuyingCode { get; set; }
        public Customer CustomerCode { get; set; }
        public DateTime BuyingDate { get; set; }
        public string BuyingTime { get; set; }
        public bool IsShipping { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public string CreditCard { get; set; }
        public string Validity { get; set; }
        public string Cvv { get; set; }
        public string IdOfCard { get; set; }
        public int BuyingPrice { get; set; }
        public override string GetTableName()
        {
            return "Buying";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "BuyingCode" };
        }

    }
}
