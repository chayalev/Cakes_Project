using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Customer:BaseEntity
    {
        public int CustomerCode { get; set; }
        public string CustomerPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerPhone { get; set; }
        public string Gmail { get; set; }
        public override string GetTableName()
        {
            return "Customer";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "CustomerCode" };
        }
    }
}
