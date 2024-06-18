using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class CakesCategoryDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            CakesCategory item = new CakesCategory();
            item.CategoryCode = (int)reader["CategoryCode"];
            item.CategoryName = reader["CategoryName"].ToString();
            return item;
        }
        public List<CakesCategory> GetList()
        {
            base.Select("CakesCategory");
            return list.Cast<CakesCategory>().ToList();
        }
        public CakesCategory GetCakesCategoryByCode(int codeC)
        {
            return GetList().FirstOrDefault(x => x.CategoryCode == codeC);
        }
        public override int GetNextKey()
        {
            if (list.Count == 0)
                return 1;
            return (GetList().Max(x => x.CategoryCode) + 1);

        }
    }
}
