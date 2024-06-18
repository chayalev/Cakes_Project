using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class MessagesDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            Messages item = new Messages();
            item.MessageCode = (int)reader["MessageCode"];
            item.CustomerCode = MyDB.Customers.GetCustomerByCode((int)reader["CustomerCode"]);
            item.IsCustomer = (bool)reader["IsCustomer"];
            item.Content = reader["Content"].ToString();
            item.Topic = reader["Topic"].ToString();
            item.IsRead = (bool)reader["IsRead"];
             return item;
        }
        
        //פעולה המחזירה רשימה של כל ההודעות
        public List<Messages> GetList()
        {
            base.Select("Messages");
            return list.Cast<Messages>().ToList();
        }
        //פעולה המקבלת קוד הודעה ומחזירה ההודעה הרצויה
        public Messages GetMessagesByCode(int codeM)
        {
            return GetList().FirstOrDefault(x => x.MessageCode == codeM);
        }
        public override int GetNextKey()
        {
            if (list.Count == 0)
                return 1;
            return (GetList().Max(x => x.MessageCode) + 1);

        }
    }
}
