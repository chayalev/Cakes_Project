using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class CustomerDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            Customer item = new Customer();
            item.CustomerCode = (int)reader["CustomerCode"];
            item.FirstName = reader["FirstName"].ToString();
            item.LastName = reader["LastName"].ToString();
            item.CustomerPhone = reader["CustomerPhone"].ToString();
            item.Gmail = reader["Gmail"].ToString();
            item.CustomerPassword = reader["CustomerPassword"].ToString();
            return item;
        }
        //פעולה המחזירה רשימה של כל הלקוחות
        public List<Customer> GetList()
        {
            base.Select("Customer");
            return list.Cast<Customer>().ToList();
        }

        //פעולה המקבלת קוד לקוח ומחזירה את הלקוח המבוקש
        public Customer GetCustomerByCode(int codeC)
        {
            return GetList().FirstOrDefault(x => x.CustomerCode == codeC);
        }
    }
}
