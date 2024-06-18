using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class StockImagesDB:BaseDB
    {
       
       

            protected override BaseEntity CreateModel()
            {
                StockImages item = new StockImages();
                item.ImageCode = (int)reader[" ImageCode"];
                item.ImageName = reader["ImageName"].ToString();
                item.ImageFile = reader["ImageFile"].ToString();
                 return item;
            }
            public List<StockImages> GetList()
            {
                base.Select("StockImages");
                return list.Cast<StockImages>().ToList();
            }
            public StockImages GetStockImagesByCode(int codeB)
            {
                return GetList().FirstOrDefault(x => x.ImageCode == codeB);
            }
        public override int GetNextKey()
        {
            if (list.Count == 0)
                return 1;
            return (GetList().Max(x => x.ImageCode) + 1);

        }

    }
}
