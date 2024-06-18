using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PicturesInCake:BaseEntity
    {
        public int CombinePictureCode { get; set; }
        public Orders OrderCode { get; set; }
        public string PictureFile { get; set; }
        public override string GetTableName()
        {
            return "PicturesInCake";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "CombinePictureCode" };
        }
    }
}
