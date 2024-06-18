using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.ServiceManager;

namespace Manager
{
    public static class Global
    {
        public static ServiceManager.ManagerClient proxy = new ServiceManager.ManagerClient();
        public static List<CakeDesserts> CakeDessertsLst = new List<CakeDesserts>();
        public static List<Orders> OrdersLst = new List<Orders>();
        public static List<BuyDetails> BuyingDetailsLst = new List<BuyDetails>();
        public static List<PicturesInCake> PicturesInCakes = new List<PicturesInCake>();

        
    }
    public enum StatusPage { Add, Update, Show }
}
