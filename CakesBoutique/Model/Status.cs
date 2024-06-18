using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Status:BaseEntity
    {
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public override string GetTableName()
        {
            return "Status";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "StatusCode" };
        }
    }
}
