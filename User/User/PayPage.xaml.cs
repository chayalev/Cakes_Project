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
using User.ClientService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PayPage : Page
    {
        bool flag;
        public PayPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ClientService.Customer c = Global.currentCustomer;
            txtName.Text = c.FirstName + " " + c.LastName;
            txtPhone.Text = c.CustomerPhone;
            txtMail.Text = c.Gmail;
            txtDate.Text = DateTime.Now.ToShortDateString();

            lvCakes.ItemsSource = Global.BuyingDetailsLst;
            lvDesignCakes.ItemsSource = Global.OrdersLst;

            txtPay.Text = PriceAllBuying().ToString();
        }

        private int PriceAllBuying()
        {
            int p = 0;
            p = Global.OrdersLst.Sum(x => x.Price);
            p += Global.BuyingDetailsLst.Sum(x => x.Amount * x.CakeCode.CakePrice);
            return p;
        }

        private void IsShiping_Click(object sender, RoutedEventArgs e)
        {
            if (IsShiping.IsChecked == true)
            {
                SpShipping.Visibility = Visibility.Visible;
                txtPay.Text = (Convert.ToInt32(txtPay.Text) + 50).ToString();

            }
            else
            {
                SpShipping.Visibility = Visibility.Collapsed;
                txtPay.Text = (Convert.ToInt32(txtPay.Text)-50).ToString();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            txtCreditEror.Text = "";
            //בדיקת מס טלפון למשלוח
            if(!Validation.IsNum(txtPhone.Text))
            {
                txtShippingEror.Text ="נתון שגוי😕";
                flag = false;
            }
            //בדיקת מס אשרא
            if (!Validation.IsNum(CreditCard.Text)|| !(CreditCard.Text.Length==16))
            {
                txtCreditEror.Text = "מספר אשראי שגוי😕";
                flag = false;
            }
            //בדיקת תוקף
            if (!Validation.IsNum(validity.Text) || !(validity.Text.Length == 4))
            {
                txtCreditEror.Text = "תוקף שגוי😕";
                flag = false;
            }
            //בדיקת cvv
            if (!Validation.IsNum(Cvv.Text) ||! (Cvv.Text.Length==3))
            {
                txtCreditEror.Text = "cvv שגוי😕";
                flag = false;
            }
            //בדיקת תז בעל הכרטיס
            if (CreditId.Text == "" || !Validation.CheckId(CreditId.Text))
            {
                txtCreditEror.Text = "ת.ז. שגוי😕";
                flag = false;
            }
            if (flag)
            {
                //הוספת ההזמנה
                Buying buying = new Buying();
                buying.BuyingCode = await Global.proxy.GetNextBuyingKeyAsync();
                buying.CustomerCode = Global.currentCustomer;
                buying.BuyingDate = DateTime.Today;
                buying.BuyingTime = DateTime.Now.ToShortTimeString();
                buying.IsShipping = IsShiping.IsChecked.Value;
                buying.ShippingAddress = ShipAddress.Text;
                buying.ShippingPhone = ShipPhon.Text;
                buying.CreditCard = CreditCard.Text;
                buying.Validity = validity.Text;
                buying.Cvv = Cvv.Text;
                buying.IdOfCard = CreditId.Text;
                buying.BuyingPrice = Convert.ToInt32(txtPay.Text);
                txtMSG.Text = "איזה כיף! הזמנתך התקבלה בהצלחה!בתאבון😋";
                await Global.proxy.AddBuyingAsync(buying, Global.BuyingDetailsLst, Global.OrdersLst, Global.PicturesInCakes, Global.lstPic);
                this.Frame.Navigate(typeof(MainPage),buying);
            }
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewOrderPage));
        }
       
    }
}
