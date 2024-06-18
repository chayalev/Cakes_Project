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
using Manager.ServiceManager;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LastOrdersPage : Page
    {
        public LastOrdersPage()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Orders> orders = await Global.proxy.GetOrdersByStatusAsync(2);
            lvLastDesserts.ItemsSource = orders;
            txtSumOrder.Text = orders.Sum(x => x.Price).ToString();
            txtCountOrder.Text = orders.Count.ToString();

        }

    }
}

