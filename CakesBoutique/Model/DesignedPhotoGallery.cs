using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DesignedPhotoGallery:BaseEntity
    {
        public int DesignedCakeCode { get; set; }
        public BaseKind BaseKind { get; set; }
        public string Picture { get; set; }
        public string Details { get; set; }
        public EventKind EventKind { get; set; }
        public int Price { get; set; }
        public override string GetTableName()
        {
            return "DesignedPhotoGallery";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "DesignedCakeCode" };
        }
    }
}
