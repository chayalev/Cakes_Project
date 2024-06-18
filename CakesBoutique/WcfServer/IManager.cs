using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ServiceModel;

namespace WcfServer
{
    [ServiceContract]
    interface IManager
    {
        [OperationContract]
        bool IsMeneger(string userName, string password);
        [OperationContract]
        List<CakesCategory> GetAllCategories();
        [OperationContract]
        List<Customer> GetAllCustomers();

        [OperationContract]
        int GetNextCategoryKey();

        [OperationContract]
        void AddNewCategory(CakesCategory category);
        [OperationContract]
        Customer GetCustomerByName(string name);
        [OperationContract]
        void AddNewCustomer(Customer c);
        [OperationContract]
        void UpdateCustomer(Customer c);
        [OperationContract]
        List<BuyDetails> GetBuyDetails(int codeBuy);
        [OperationContract]
        List<Buying> GetAllBuyings();
        [OperationContract]
        List<CakeDesserts> GetAllCakeDesserts();
      
        [OperationContract]
        int GetNextBuyingKey();
        [OperationContract]
        List<EventKind> GetAllEventsKind();
        [OperationContract]
        List<BaseKind> GetAllBaseKind();
        [OperationContract]
        List<DesignedPhotoGallery> GetAllDesignedPhotoGallery();
        [OperationContract]
        List<DesignedPhotoGallery> GetDesignedPhotoGalleriesByBaseKindAndEvent(int baseKind, int eventKind);
        [OperationContract]
        List<Orders> GetOrderByCodeBuying(int codeBuy);
        [OperationContract]
        void AddBuying(Buying buying, List<BuyDetails> buyDetails, List<Orders> orders, List<PicturesInCake> pics);
        [OperationContract]
        Status GetStatusByCode(int code);
        [OperationContract]
        List<BuyDetails> GetAllbuyDetails();

        [OperationContract]
        List<Buying> GetBuyingsByCustomer(Customer customer);
        [OperationContract]
        List<BuyDetails> GetBuyDetailsByBuying(int buying);
        [OperationContract]
        List<Orders> GetOrdersByBuying(int buying);
        [OperationContract]
        byte[] GetImage(string fileName);
        [OperationContract]
        void AddPictureInCake(PicturesInCake pic, byte[] fileImage);
        [OperationContract]
        List<CakeDesserts> GetCakeDessertsByCategoryCode(int cakesCategoryCode);
        [OperationContract]
        void UpdateCakeDessert(CakeDesserts cakeDesserts);
        [OperationContract]
        void AddNewCakeDesserts(CakeDesserts c);
        [OperationContract]
        List<StockImages> GetAllStockImages();
        [OperationContract]
        void UpdateCategory(CakesCategory category);
        [OperationContract]
        int GetNextCakeKey();
        [OperationContract]
        int GetNextMessagesKey();
        [OperationContract]
        void AddNewMessages(Messages messages);
        [OperationContract]
        List<Messages> GetAllMessages();
        [OperationContract]
        List<Messages> GetMessagesByCustomer(Customer o);
        [OperationContract]
        void ReadAllMessages(Customer o);
        [OperationContract]
        List<Orders> GetAllOrders();
        [OperationContract]
        List<Orders> GetOrdersByStatus(int status);
        [OperationContract]
        List<Orders> GetOrdersByDate(DateTime date);
        [OperationContract]
        void UpdatOrder(Orders o);
        [OperationContract]
        List<Orders> GetOrdersByCustomer(Customer customer);
        [OperationContract]
         List<Orders> GetOrdersByWeek(DateTime date);
        [OperationContract]
        List<PicturesInCake> GetAllPictures();
        [OperationContract]
       List< PicturesInCake> GetPicturesByOrderCode(Orders o);
    }

}
