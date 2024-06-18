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
    public sealed partial class CustomerCredit : Page
    {
        Customer c;
        public CustomerCredit()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Customer)
            {
                c = e.Parameter as Customer;
                txtCode.Text = c.CustomerCode.ToString();
                txtName.Text = c.FirstName + " " + c.LastName;
                txtPhone.Text = c.CustomerPhone;
                txtMail.Text = c.Gmail;
            }

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        { 
            lvLastOrders.ItemsSource = await Global.proxy.GetBuyingsByCustomerAsync(c);
        }

        private void btnDesignOrders_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllMyDesignCake),c);
        }

         private async void btnAllOeders_Click(object sender, RoutedEventArgs e)
        {
            lvLastOrders.ItemsSource = await Global.proxy.GetBuyingsByCustomerAsync(c);
        }

       
    }
}
