using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BaseKindDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            BaseKind item = new BaseKind();
            item.KindCode = (int)reader["KindCode"];
            item.KindName = reader["KindName"].ToString();
            return item;
        }
        public List<BaseKind> GetList()
        {
            base.Select("BaseKind");
            return list.Cast<BaseKind>().ToList();
        }
        public BaseKind GetBaseKindByCode(int codeB)
        {
            return GetList().FirstOrDefault(x => x.KindCode == codeB);
        }
        public override int GetNextKey()
        {
            if (list.Count == 0)
                return 1;
            return (GetList().Max(x => x.KindCode) + 1);

        }

    }
}
