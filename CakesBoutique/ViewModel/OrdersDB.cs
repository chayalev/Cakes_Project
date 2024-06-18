using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class OrdersDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            Orders item = new Orders();
            item.OrderCode = (int)reader["OrderCode"];
            item.BuyingCode = MyDB.Buyings.GetBuyingByCode((int)reader["BuyingCode"]);
            item.CakeKind = MyDB.BaseKinds.GetBaseKindByCode((int)reader["CakeKind"]);
            item.CakeExampleCode = MyDB.DesignedPhotoGalleries.GetDesignedPhotoGalleryByCode((int)reader["CakeExampleCode"]);
            item.Remarks = reader["Remarks"].ToString();
            item.Price = (int)reader["Price"];
            item.DateGoal = Convert.ToDateTime(reader["DateGoal"]);
            item.StatusCode =MyDB.Status.GetStatusByCode( (int)reader["StatusCode"]);
            return item;
        }

         //פעולה המחזירה רשימה של כל ההזמנות
        public List<Orders> GetList()
        {
            base.Select("Orders");
            return list.Cast<Orders>().ToList();
        }
        //פעולה המקבלת קוד הזמנה ומחזירה את ההזמנה הרצויה
        public Orders GetOrdersByCode(int codeO)
        {
            return GetList().FirstOrDefault(x => x.OrderCode == codeO);
        }
        public override int GetNextKey()
        {
            if (GetList().Count == 0)
                return 1;
            return (GetList().Max(x => x.OrderCode) + 1);

        }
    }
}
