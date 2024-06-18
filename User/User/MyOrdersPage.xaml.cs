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
using User.ClientService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyOrdersPage : Page
    {
        public MyOrdersPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            lvMyOrders.ItemsSource = await Global.proxy.GetBuyingsByCustomerAsync(Global.currentCustomer);
        }

        //private void btnPlus_Click(object sender, RoutedEventArgs e)
        //{
        //    
        //}

        private void BMenue_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AfterConnectPage));
        }

        private async void btnPlus_Click(object sender, RoutedEventArgs e)
        {
             stDetails.Visibility = Visibility.Visible;
            lvOrdersDetails.ItemsSource = await Global.proxy.GetBuyDetailsByBuyingAsync((((Button)sender).DataContext as Buying).BuyingCode );
        }
    }
}
