using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class EventKind:BaseEntity
    {
        public int EventKindCode { get; set; }
        public string EventKindName { get; set; }
        public override string GetTableName()
        {
            return "EventKind";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "EventKindCode" };
        }
    }
}
