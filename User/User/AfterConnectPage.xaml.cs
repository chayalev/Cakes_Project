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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AfterConnectPage : Page
    {
        public AfterConnectPage()
        {
            this.InitializeComponent();

            if (Global.currentCustomer != null)
                txtNameUser.Text = Global.currentCustomer.FirstName + " " + Global.currentCustomer.LastName;
        }

        

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

    
        private void BKatalog_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KatalogPage));
        }

        private void BNewOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewOrderPage));
        }

        private void btnEditDetails_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCustomerPage), Global.currentCustomer);
        }

        private void BMenue_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BMyDetails_Click(object sender, RoutedEventArgs e)
        {
           
            this.Frame.Navigate(typeof(NewCustomerPage), Global.currentCustomer);
        }

        private void BOrdres_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyOrdersPage), Global.currentCustomer);
        }
    }
}
