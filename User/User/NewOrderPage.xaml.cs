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
using System.ServiceModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewOrderPage : Page
    {
        //תמחור
        //מחיר דגם עוגה + 30 שח לתמונה אישית + תאריך עד 2 ימים תוספת 10%
        //שינוי מחיר עי המנהל במהלך צאט
        int a = 0;
        int x = 0;
        int c = 0;
        public NewOrderPage()
        {
            this.InitializeComponent();
        }
        private int PriceAllBuying()
        {
            int p = 0;
            p = Global.OrdersLst.Sum(x => x.Price);
            p += Global.BuyingDetailsLst.Sum(x => x.Amount * x.CakeCode.CakePrice);
            return p;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ClientService.Customer c = Global.currentCustomer;
            txtName.Text = c.FirstName + " " + c.LastName;
            txtPhone.Text = c.CustomerPhone;
            txtMail.Text = c.Gmail;
            lvDesignCake.ItemsSource = Global.OrdersLst;
            lvCakeDessert.ItemsSource = Global.BuyingDetailsLst;   
           txtFinalPrice.Text=PriceAllBuying().ToString(); 
        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KatalogPage));
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PayPage));
        }

            
        private void DesingCake_Click(object sender, RoutedEventArgs e)
        {
           
               this.Frame.Navigate(typeof(DesignCakesPage));
          }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AfterConnectPage));
        }
        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AfterConnectPage));
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
