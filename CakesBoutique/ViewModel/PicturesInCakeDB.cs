using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class PicturesInCakeDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            PicturesInCake item = new PicturesInCake();
            item.CombinePictureCode = (int)reader["CombinePictureCode"];
            item.OrderCode = MyDB.Orders.GetOrdersByCode((int)reader["OrderCode"]);
            item.PictureFile = reader["PictureFile"].ToString();
             return item;
        }
        public List<PicturesInCake> GetList()
        {
            base.Select("PicturesInCake");
            return list.Cast<PicturesInCake>().ToList();
        }
        public PicturesInCake GetPicturesInCakeByCode(int codeO)
        {
            return GetList().FirstOrDefault(x => x.CombinePictureCode == codeO);
        }
        public override int GetNextKey()
        {
            if (GetList().Count == 0)
                return 1;
            return (GetList().Max(x => x.CombinePictureCode) + 1);

        }
    }

}

