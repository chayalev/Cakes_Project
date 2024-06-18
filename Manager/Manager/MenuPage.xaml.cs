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

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }

        private void BCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllCustomerPage));
        }

      

        
        private void navCakeDessert_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameMain.Navigate(typeof(CakeDessertPage));
        }

        private void navCust_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameMain.Navigate(typeof(AllCustomerPage));
        }

          private void navWeitingOrders_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameMain.Navigate(typeof(WaitingOrdersPage));
        }

        private void navLastOrders_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameMain.Navigate(typeof(LastOrdersPage));
        }

        private void navNewCake_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameMain.Navigate(typeof(AddUpdateCake));
        }
    }
}
