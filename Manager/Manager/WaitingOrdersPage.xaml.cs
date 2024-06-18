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
using Manager.ServiceManager;
using System.ServiceModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WaitingOrdersPage : Page
    {
        Orders o;
        public WaitingOrdersPage()
        {
            this.InitializeComponent();
        }


        private async void btnDay_Click(object sender, RoutedEventArgs e)
        {
            lvWeitingOrders.ItemsSource = await Global.proxy.GetOrdersByDateAsync(DateTime.Today);
          
        }

        private async void btnWeek_Click(object sender, RoutedEventArgs e)
           
        {
           lvWeitingOrders.ItemsSource = await Global.proxy.GetOrdersByWeekAsync(DateTime.Today);
        }

        private async void btnEverything_Click(object sender, RoutedEventArgs e)
        {
            lvWeitingOrders.ItemsSource = await Global.proxy.GetOrdersByStatusAsync(1);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
           lvWeitingOrders.ItemsSource = await Global.proxy.GetOrdersByStatusAsync(1);
        }

         private void lvWeitingOrders_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void cStatus_Checked(object sender, RoutedEventArgs e)
        {
            Orders o = ((CheckBox)sender).DataContext as Orders;
            o.StatusCode =await Global.proxy.GetStatusByCodeAsync(2);
            await Global.proxy.UpdatOrderAsync(o);
            lvWeitingOrders.ItemsSource = await Global.proxy.GetOrdersByStatusAsync(1);
        }
    }
}
