using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
     public class BuyDetailsDB:BaseDB
    {
        //פעולה המחזירה רשימה של כל פרטי הקניה
        public List<BuyDetails> GetList()
            {
                base.Select("BuyDetails");
                return list.Cast<BuyDetails>().ToList();
            }
            protected override BaseEntity CreateModel()
            {
               BuyDetails item = new BuyDetails();
               item.DetailsCode = (int)reader["DetailsCode"];
               item.BuyingCode =MyDB.Buyings.GetBuyingByCode( (int)reader["BuyingCode"]);
               item.CakeCode = MyDB.CakeDesserts.GetCakeDessertsByCode((int)reader["CakeCode"]);
               item.Amount = (int)reader["Amount"];
            item.StatusCode = MyDB.Status.GetStatusByCode((int)reader["StatusCode"]);
               return item;

            }
        //פעולה המקבלת קוד פרטי הקניה ומחזירה את פרטי הקניה המבוקשים
           public BuyDetails GetBuyDetailsByCode(int codeB)
           {
              return GetList().FirstOrDefault(x => x.DetailsCode == codeB);
            }
      
        public override int GetNextKey()
        {
            if (GetList().Count == 0)
                return 1;
            return (GetList().Max(x => x.DetailsCode) + 1);

        }
    }
}
