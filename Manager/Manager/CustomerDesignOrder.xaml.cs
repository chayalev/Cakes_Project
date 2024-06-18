using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using System.ServiceModel;
using Manager.ServiceManager;
using Windows.UI.Text;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerDesignOrder : Page
    {
        Customer c;
        Orders order;
        public CustomerDesignOrder()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Orders)
            {
                order = (Orders)e.Parameter;
                c = order.BuyingCode.CustomerCode;
                txtName.Text = c.FirstName + " " + c.LastName;
                txtPhone.Text = c.CustomerPhone;
                txtMail.Text = c.Gmail;
                txtRemarks.Text=order.Remarks;
                txtExample.Text=order.CakeExampleCode.DesignedCakeCode.ToString();
                txtDateOfEvent.Text = order.DateGoal.ToString();
                txtPrice.Text = order.Price.ToString();
               // הוספת תמונה
                //List<PicturesInCake> lst = await Global.proxy.GetPicturesByOrderCodeAsync(order);
                //foreach (PicturesInCake p in lst)
                //{
                //    byte[] picArr = await Global.proxy.GetImageAsync(p.PictureFile);
                //    BitmapImage image = new BitmapImage();
                //    ImageConvert.ConvertByteArrayToImage(picArr, image);
                //    CustomerImage.Source = image;
                //}

            }

            ShowChat();
            
        }
       
        private  void txtTyping_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            //הוספת הודעה
            Messages m = new Messages();
            m.MessageCode = await Global.proxy.GetNextMessagesKeyAsync();
            m.CustomerCode = c;
            m.IsCustomer=false;
            m.Topic = txtTyping.Text;
            await Global.proxy.AddNewMessagesAsync(m);

            ShowChat();
            txtTyping.Text = "";
        }
        private async void ShowChat()
        {
            Chat.Children.Clear();
            List<Messages> messages = await Global.proxy.GetMessagesByCustomerAsync(c);
            foreach (var item in messages)
            {
                Border b = new Border();
                b.Margin = new Thickness(5);
                TextBlock t = new TextBlock();
                t.TextWrapping = TextWrapping.Wrap;
                t.Text = item.Topic;
                b.Child = t;
               // מהלקוח
                if (item.IsCustomer)
                {
                    t.HorizontalAlignment = HorizontalAlignment.Left;
                    t.TextAlignment = TextAlignment.Left;
                    b.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 240, 164, 164));
                    if (!item.IsRead)
                    {
                       // הדגשה
                        FontWeight w = new FontWeight();
                        w.Weight = 500;
                        t.FontWeight = w;
                    }
                }

                else//מהקונדיטורית
                {
                    t.HorizontalAlignment = HorizontalAlignment.Right;
                    t.TextAlignment = TextAlignment.Right;
                    b.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 8, 194, 232));
                }

                Chat.Children.Add(b);
            }
        }

        private async void txtTyping_GotFocus(object sender, RoutedEventArgs e)
        {
            await Global.proxy.ReadAllMessagesAsync(c);
            ShowChat();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            order.Price = Convert.ToInt32(txtPrice.Text);
            await Global.proxy.UpdatOrderAsync(order);
            txtUpdateOk.Text = "העדכון בוצע בהצלחה🤗";
        }
    }
}
