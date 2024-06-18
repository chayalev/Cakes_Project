using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Orders :BaseEntity
    {
        public int OrderCode { get; set; }
        public Buying BuyingCode { get; set; }
        public BaseKind CakeKind { get; set; }
        public DesignedPhotoGallery CakeExampleCode { get; set; }
        public string Remarks { get; set; }
        public int Price { get; set; }
        public DateTime DateGoal { get; set; }  
        public Status StatusCode { get; set; }
        public override string GetTableName()
        {
            return "Orders";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "OrderCode" };
        }
    }
}
