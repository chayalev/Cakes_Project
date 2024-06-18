using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class StatusDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            Status item = new Status();
            item.StatusCode = (int)reader["StatusCode"];
            item.StatusName = reader["StatusName"].ToString();
            return item;
        }
        public List<Status> GetList()
        {
            base.Select("Status");
            return list.Cast<Status>().ToList();
        }
        public Status GetStatusByCode(int codeS)
        {
            return GetList().FirstOrDefault(x => x.StatusCode == codeS);
        }
        public override int GetNextKey()
        {
            if (list.Count == 0)
                return 1;
            return (GetList().Max(x => x.StatusCode) + 1);

        }
    }
}
