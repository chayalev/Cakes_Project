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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (Global.currentCustomer != null)
            {
                txtNameUser.Text = Global.currentCustomer.FirstName + " " + Global.currentCustomer.LastName;
                btnConnect.Visibility = Visibility.Collapsed;
                btnNewClient.Visibility = Visibility.Collapsed;
                btnUserDetails.Visibility = Visibility.Visible;
            }
            if (e.Parameter != null)
            {
                Global.OrdersLst.Clear();
                Global.BuyingDetailsLst.Clear();
            }
        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ConnectPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
      
        }

        private void btnNewClient_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCustomerPage));
        }

        private void BKatalog_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KatalogPage));
        }

        private void BDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailsPage));

        }

        private void btnEditDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCustomerPage), Global.currentCustomer);
        }

        private void btnExitDetails_Click(object sender, RoutedEventArgs e)
        {
            Global.currentCustomer = null;
            Global.OrdersLst.Clear();
            Global.BuyingDetailsLst.Clear();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnCustomerPage_Click()
        {

        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AfterConnectPage), Global.currentCustomer);
        }
    }

}
