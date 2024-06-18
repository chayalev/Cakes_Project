using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
   public class DesignedPhotoGalleryDB:BaseDB
    {
        protected override BaseEntity CreateModel()
        {
            DesignedPhotoGallery item = new DesignedPhotoGallery();
            item.DesignedCakeCode = (int)reader["DesignedCakeCode"];
            item.BaseKind = MyDB.BaseKinds.GetBaseKindByCode((int)reader["BaseKind"]);
            item.Picture = reader["Picture"].ToString();
            item.Details = reader["Details"].ToString();
            item.EventKind = MyDB.EventKinds.GetEventKindByCode((int)reader["EventKind"]);
            item.Price = (int)reader["Price"];
            return item;
        }
        public List<DesignedPhotoGallery> GetList()
        {
            base.Select("DesignedPhotoGallery");
            return list.Cast<DesignedPhotoGallery>().ToList();
        }
        public DesignedPhotoGallery GetDesignedPhotoGalleryByCode(int codeD)
        {
            return GetList().FirstOrDefault(x => x.DesignedCakeCode == codeD);
        }
    }
}
