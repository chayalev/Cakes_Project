using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public static class MyDB
    {
        public static BaseKindDB BaseKinds = new BaseKindDB();
        public static BuyDetailsDB BuyDetails = new BuyDetailsDB();
        public static BuyingDB Buyings= new BuyingDB();
        public static CakeDessertsDB CakeDesserts = new CakeDessertsDB();
        public static CakesCategoryDB CakesCategories = new CakesCategoryDB();
        public static CustomerDB Customers = new CustomerDB();
        public static DesignedPhotoGalleryDB DesignedPhotoGalleries = new DesignedPhotoGalleryDB();
        public static EventKindDB EventKinds = new EventKindDB();
        public static MessagesDB Messages = new MessagesDB();
        public static OrdersDB Orders = new OrdersDB();
        public static PicturesInCakeDB PicturesInCakes = new PicturesInCakeDB();
        public static StockImagesDB StockImages = new StockImagesDB();
        public static StatusDB Status = new StatusDB();


    }
}
