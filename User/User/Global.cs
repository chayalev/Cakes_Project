using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.ClientService;

namespace User
{
    public static class Global
    {
        public static ClientClient proxy = new ClientService.ClientClient();
        public static Customer currentCustomer;
        public static List<Orders> OrdersLst = new List<Orders>();
        public static List<BuyDetails> BuyingDetailsLst= new List<BuyDetails>();
        public static List<PicturesInCake> PicturesInCakes = new List<PicturesInCake>();
        public static List<byte[]> lstPic = new List<byte[]>();
        public enum StatusPage { Add,Update,Show }
    }
}



