using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Messages:BaseEntity
    {
        public int MessageCode { get; set; }
        public  Customer CustomerCode{ get; set; }
        public bool IsCustomer { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public bool IsRead { get; set; }
        public override string GetTableName()
        {
            return "Messages";
        }
        public override string[] GetKeyFields()
        {
            return new string[] { "MessageCode" };
        }
    }
}
