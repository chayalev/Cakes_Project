using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BuyingDB:BaseDB
    {

        protected override BaseEntity CreateModel()
        {
            Buying item = new Buying();
            item.BuyingCode = (int)reader["BuyingCode"];
            item.CustomerCode = MyDB.Customers.GetCustomerByCode((int) reader["CustomerCode"]);
            item.BuyingDate = (DateTime)reader["BuyingDate"];
            item.BuyingTime = reader["BuyingTime"].ToString();
            item.IsShipping = (bool)reader["IsShipping"];
            item.ShippingAddress = reader["ShippingAddress"].ToString();
            item.ShippingPhone = reader["ShippingPhone"].ToString();
            item.CreditCard = reader["CreditCard"].ToString();
            item.Validity = reader["Validity"].ToString();
            item.Cvv = reader["Cvv"].ToString();
            item.IdOfCard = reader["IdOfCard"].ToString();
            item.BuyingPrice = (int)reader["BuyingPrice"];
            return item;
        }
        //פעולה המחזירה רשימה של כל הקניות
        public List<Buying> GetList()
        {
            base.Select("Buying");
            return list.Cast<Buying>().ToList();
        }
        //פעולה המקבלת את קוד הקניה ומחזירה את הקניה הרצויה 
        public Buying GetBuyingByCode(int codeB)
        {
            return GetList().FirstOrDefault(x => x.BuyingCode == codeB);
        }
        public override int GetNextKey()
        {
            if (GetList().Count == 0)
                return 1;
            return (GetList().Max(x => x.BuyingCode) + 1);

        }
    }
}
