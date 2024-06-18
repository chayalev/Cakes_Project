using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseKind:BaseEntity
    {
        public int KindCode { get; set; }
        public string KindName { get; set; }
        public override string GetTableName()
        {
            return "BaseKind";
        }
        public override string [] GetKeyFields()
        {
            return new string[] { "KindCode" };
        }
      
       
    }
}
