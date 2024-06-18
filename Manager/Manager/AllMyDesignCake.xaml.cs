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
    public sealed partial class AllMyDesignCake : Page
    {
        Customer c;
        public AllMyDesignCake()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Customer)
            {
               c = (Customer)e.Parameter;
            }
          
        }

          private void btnOrder_Click(object sender, RoutedEventArgs e)

        {
            this.Frame.Navigate(typeof(CustomerDesignOrder), (Orders)((Button)sender).DataContext);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
          lvMyOrders.ItemsSource = await Global.proxy.GetOrdersByCustomerAsync(c);
        }

        private void btnSeeDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CustomerDesignOrder), (Orders)((Button)sender).DataContext);
        }
    }
}
