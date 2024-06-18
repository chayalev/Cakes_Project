using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StockImages:BaseEntity
    {
        public int ImageCode { get; set; }
        public string ImageName { get; set; }
        public string ImageFile { get; set; }
        public override string GetTableName()
        {
            return "StockImages";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "ImageCode" };
        }
    }
}
