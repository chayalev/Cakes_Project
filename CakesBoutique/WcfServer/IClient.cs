using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using System.ServiceModel;
using Model;

namespace WcfServer
{
    [ServiceContract]
    interface IClient
    {
        [OperationContract]
        bool IsPasswordClient(string name, string password);
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
        List<CakesCategory> GetAllCategories();
  
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
        void AddBuying(Buying buying, List<BuyDetails> buyDetails, List<Orders> orders , List<PicturesInCake> pics,List<byte[]> lstPic);
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
        List<Orders> GetAllOrders();
        [OperationContract]
        List<Orders> GetAllOrdersByBuyingCode(int buying);[OperationContract]
        int GetNextMessagesKey();
        [OperationContract]
        void AddNewMessages(Messages messages);
        [OperationContract]
        List<Messages> GetAllMessages();
        [OperationContract]
        List<Messages> GetMessagesByCustomer(Customer o);
        [OperationContract]
        void ReadAllMessages(Customer o);
    }

}
