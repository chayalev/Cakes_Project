﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Model;
using System.ServiceModel;
using System.IO;

namespace WcfServer
{
   
    public class Client:IClient
    {
        
        public bool IsPasswordClient(string name, string password)
        {
            return MyDB.Customers.GetList().Exists(x => (x.FirstName +" "+ x.LastName == name) && (x.CustomerPassword == password));
        }
        public Customer GetCustomerByName(string name)
        {
            return MyDB.Customers.GetList().Find(x => x.FirstName+" "+x.LastName == name);
        }
        public void AddNewCustomer(Customer c)
        {
            MyDB.Customers.Add(c);
            MyDB.Customers.SaveChanges();
        }
        public void UpdateCustomer(Customer c)
        {
            MyDB.Customers.Update(c);
            MyDB.Customers.SaveChanges();
        }

        public List<BuyDetails> GetBuyDetails(int codeBuy)
        {
            return MyDB.BuyDetails.GetList().Where(x => x.BuyingCode.BuyingCode == codeBuy).ToList() ;
        }

        public List<Buying> GetAllBuyings()
        {
            return MyDB.Buyings.GetList();
        }

        public List<CakeDesserts> GetAllCakeDesserts()
        {
            return MyDB.CakeDesserts.GetList();
        }

        public List<CakesCategory> GetAllCategories()
        {
            return MyDB.CakesCategories.GetList();
        }


        public int GetNextBuyingKey()
        {
            return MyDB.Buyings.GetNextKey();
        }

        public List<EventKind> GetAllEventsKind()
        {
            return MyDB.EventKinds.GetList();
        }

        public List<BaseKind> GetAllBaseKind()
        {
            return MyDB.BaseKinds.GetList(); ;
        }

        public List<DesignedPhotoGallery> GetAllDesignedPhotoGallery()
        {
            return MyDB.DesignedPhotoGalleries.GetList();
        }

        public List<DesignedPhotoGallery> GetDesignedPhotoGalleriesByBaseKindAndEvent(int baseKind, int eventKind)
        {
            return MyDB.DesignedPhotoGalleries.GetList().Where(x=> x.BaseKind.KindCode==baseKind && x.EventKind.EventKindCode==eventKind).ToList();
        }

        public List<Orders> GetOrderByCodeBuying(int codeBuy)
        {
            return MyDB.Orders.GetList().Where(x=> x.BuyingCode.BuyingCode==codeBuy).ToList();
        }

        public void AddBuying(Buying buying, List<BuyDetails> buyDetails, List<Orders> orders, List<PicturesInCake> pics,List<byte[]> lstPic)
        {
            MyDB.Buyings.Add(buying);
            MyDB.Buyings.SaveChanges();

            int x = MyDB.BuyDetails.GetNextKey();
            foreach (var item in buyDetails)
            {
                item.DetailsCode= x;
                item.BuyingCode = buying;
                x++;
                MyDB.BuyDetails.Add(item);
            }
            MyDB.BuyDetails.SaveChanges();

            x=MyDB.Orders.GetNextKey(); 
            foreach (var item in orders)
            {
                item.OrderCode= x;
                item.BuyingCode = buying;
                x++;
                MyDB.Orders.Add(item);
            }
            MyDB.Orders.SaveChanges();
            
            x=MyDB.PicturesInCakes.GetNextKey();
            int i = 0;
            foreach (var item in pics)
            {
                item.CombinePictureCode= x;
                x++;

                Orders o = MyDB.Orders.GetList().FirstOrDefault(y => y.CakeKind.KindCode == item.OrderCode.CakeKind.KindCode && y.CakeExampleCode.DesignedCakeCode == item.OrderCode.CakeExampleCode.DesignedCakeCode);
                item.OrderCode = o;
         
                MyDB.PicturesInCakes.Add(item);
                File.WriteAllBytes(BaseDB.GetCurrentPath() + @"\Pictures\" + item.PictureFile, lstPic[i]);
                i++;
            }
            MyDB.PicturesInCakes.SaveChanges();


        }

        public Status GetStatusByCode(int code)
        {
            return MyDB.Status.GetStatusByCode(code);
        }

        public List<BuyDetails> GetAllbuyDetails()
        {
           return MyDB.BuyDetails.GetList();
        }

        public List<Buying> GetBuyingsByCustomer(Customer customer)
        {
           return MyDB.Buyings.GetList().Where(x=> x.CustomerCode.CustomerCode==customer.CustomerCode).ToList();
        }

        public List<BuyDetails> GetBuyDetailsByBuying(int buyingCode)
        {
           return MyDB.BuyDetails.GetList().Where(x=> x.BuyingCode.BuyingCode==buyingCode).ToList(); ;
        }

        public List<Orders> GetOrdersByBuying(int buying)
        {
            return MyDB.Orders.GetList().Where(x => x.BuyingCode.BuyingCode == buying).ToList();
        }
        public byte[] GetImage(string fileName)
        {
            string path = BaseDB.GetCurrentPath() + @"\Pictures\" + fileName;
            if (File.Exists(path))
                return File.ReadAllBytes(path);
            return File.ReadAllBytes(BaseDB.GetCurrentPath() + @"\Pictures\Defualt.jpg"); ;//או תמונת ברירת מחדל
        }

        public void AddPictureInCake(PicturesInCake pic, byte[] fileImage)
        {
            pic.CombinePictureCode = MyDB.PicturesInCakes.GetNextKey();
            MyDB.PicturesInCakes.Add(pic);
            MyDB.PicturesInCakes.SaveChanges();

            //לשמור את התמונה בתיקיה Pictures
            File.WriteAllBytes(BaseDB.GetCurrentPath() + @"\Pictures\" + pic.PictureFile, fileImage);
        }

        public List<CakeDesserts> GetCakeDessertsByCategoryCode(int cakesCategoryCode)
        {
            return MyDB.CakeDesserts.GetList().Where(x => x.CakeCategory.CategoryCode==cakesCategoryCode).ToList();
        }

          public List<Orders> GetAllOrders()
        {
            return MyDB.Orders.GetList();
        }

        public List<Orders> GetAllOrdersByBuyingCode(int buying)
        {
            return MyDB.Orders.GetList().Where(x=> x.BuyingCode.BuyingCode==buying).ToList();
        }
        public int GetNextMessagesKey()
        {
            return MyDB.Messages.GetNextKey();
        }

        public void AddNewMessages(Messages messages)
        {
            MyDB.Messages.Add(messages);
            MyDB.Messages.SaveChanges();
        }

        public List<Messages> GetAllMessages()
        {
            return MyDB.Messages.GetList();
        }

        public List<Messages> GetMessagesByCustomer(Customer o)
        {
            return MyDB.Messages.GetList().Where(x => x.CustomerCode.CustomerCode == o.CustomerCode).ToList();
        }

        public void ReadAllMessages(Customer o)
        {
            List<Messages> mas = MyDB.Messages.GetList().Where(x => x.CustomerCode.CustomerCode == o.CustomerCode && !x.IsCustomer && !x.IsRead).ToList();
            foreach (var item in mas)
            {
                item.IsRead = true;
                MyDB.Messages.Update(item);
            }
            MyDB.Messages.SaveChanges();
        }

        }
}

