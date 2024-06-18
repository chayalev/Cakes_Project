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
    public sealed partial class ConnectPage : Page
    {
        ClientService.ClientClient proxy = new ClientService.ClientClient();
        public ConnectPage()
        {
            this.InitializeComponent();
        }

        private async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            txtError.Visibility = Visibility.Collapsed;
            if (await proxy.IsPasswordClientAsync(txtUserName.Text, txtUserPassword.Password))
            {
                Global.currentCustomer = await proxy.GetCustomerByNameAsync(txtUserName.Text);
                this.Frame.Navigate(typeof(AfterConnectPage));
            }
            else
            {
                txtError.Visibility = Visibility.Visible;
            }
        }

        private void BMenue_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
