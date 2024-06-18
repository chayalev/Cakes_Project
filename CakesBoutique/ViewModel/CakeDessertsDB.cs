using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class CakeDessertsDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            CakeDesserts item = new CakeDesserts();
            item.CakeCode = (int)reader["CakeCode"];
            item.CakeName = reader["CakeName"].ToString();
            item.CakeDetails = reader["CakeDetails"].ToString();
            item.CakePrice = (int)reader["CakePrice"];
            item.CakeCategory = MyDB.CakesCategories.GetCakesCategoryByCode((int)reader["CakeCategory"]);
            item.CakePicture = reader["CakePicture"].ToString();
            item.IsDairy = (bool)reader["IsDairy"];
            return item;
        }
        public List<CakeDesserts> GetList()
        {
            base.Select("CakeDesserts");
            return list.Cast<CakeDesserts>().ToList();
        }
        public CakeDesserts GetCakeDessertsByCode(int codeC)
        {
            return GetList().FirstOrDefault(x => x.CakeCode == codeC);
        }
        public override int GetNextKey()
        {
            if (GetList().Count == 0)
                return 1;
            return (GetList().Max(x => x.CakeCode) + 1);

        }
    }
}
