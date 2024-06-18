using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class EventKindDB:BaseDB
    {
           protected override BaseEntity CreateModel()
            {
                EventKind item = new EventKind();
                item.EventKindCode = (int)reader["EventKindCode"];
                item.EventKindName = reader["EventKindName"].ToString();
                 return item;
            }
            public List<EventKind> GetList()
            {
                base.Select("EventKind");
                return list.Cast<EventKind>().ToList();
            }
            public EventKind GetEventKindByCode(int codeB)
            {
                return GetList().FirstOrDefault(x => x.EventKindCode == codeB);
            }
        public override int GetNextKey()
        {
            if (list.Count == 0)
                return 1;
            return (GetList().Max(x => x.EventKindCode) + 1);

        }

    }
}
