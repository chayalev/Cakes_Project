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
using User.ClientService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KatalogPage : Page
    {
        List<ClientService.CakeDesserts> cakeDesserts=new List<ClientService.CakeDesserts>();
        public KatalogPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            cakeDesserts =await Global.proxy.GetAllCakeDessertsAsync();
            foreach (var item in cakeDesserts)
            {
                UCCakeKatalog uCCake = new UCCakeKatalog(item);
                uCCake.Margin = new Thickness(10);
                CakesList.Children.Add(uCCake);
            }
            
        }

        private void BMenue_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            SKSelect.Visibility = Visibility.Visible;
            btnSelect.Visibility = Visibility.Collapsed;
        }

        private async void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (Global.currentCustomer == null)
            {
                txtMSG.Text = "אופססס....שכחת להתחבר!חזור לתפריט הראשי,הכנס את פרטיך ואז רוץ להזמין!";
              
            }
            else
            {
                int x = await Global.proxy.GetNextBuyingKeyAsync();
                foreach (var item in CakesList.Children)
                {

                    UCCakeKatalog uCCake = item as UCCakeKatalog;
                    if (uCCake.Amount() > 0)
                    {
                        BuyDetails buyDetails = new BuyDetails();

                        buyDetails.CakeCode = uCCake.cake;
                        buyDetails.Amount = uCCake.Amount();
                        buyDetails.StatusCode = await Global.proxy.GetStatusByCodeAsync(1);

                        Global.BuyingDetailsLst.Add(buyDetails);
                    }

                }
                this.Frame.Navigate(typeof(NewOrderPage));
            }
        }

        private void BMenue_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnVitrina_Click(object sender, RoutedEventArgs e)
        {
            CakesList.Children.Clear();
            cakeDesserts = await Global.proxy.GetCakeDessertsByCategoryCodeAsync(1);
            foreach (var item in cakeDesserts)
            {
                UCCakeKatalog uCCake = new UCCakeKatalog(item);

                uCCake.Margin = new Thickness(10);
                CakesList.Children.Add(uCCake);
            }
        }

        private async void btnDessert_Click(object sender, RoutedEventArgs e)
        {
            CakesList.Children.Clear();
            cakeDesserts = await Global.proxy.GetCakeDessertsByCategoryCodeAsync(4);
            foreach (var item in cakeDesserts)
            {
                UCCakeKatalog uCCake = new UCCakeKatalog(item);

                uCCake.Margin = new Thickness(10);
                CakesList.Children.Add(uCCake);
            }
        }

        private async void btnHomeCake_Click(object sender, RoutedEventArgs e)
        {
            CakesList.Children.Clear();
            cakeDesserts = await Global.proxy.GetCakeDessertsByCategoryCodeAsync(2);
            foreach (var item in cakeDesserts)
            {
                UCCakeKatalog uCCake = new UCCakeKatalog(item);

                uCCake.Margin = new Thickness(10);
                CakesList.Children.Add(uCCake);
            }
        }

        private async void btnBox_Click(object sender, RoutedEventArgs e)
        {
            CakesList.Children.Clear();
            cakeDesserts = await Global.proxy.GetCakeDessertsByCategoryCodeAsync(3);
            foreach (var item in cakeDesserts)
            {
                UCCakeKatalog uCCake = new UCCakeKatalog(item);

                uCCake.Margin = new Thickness(10);
                CakesList.Children.Add(uCCake);
            }
        }

        private async void btnEverything_Click(object sender, RoutedEventArgs e)
        {
            CakesList.Children.Clear();
            cakeDesserts = await Global.proxy.GetAllCakeDessertsAsync();
            foreach (var item in cakeDesserts)
            {
                UCCakeKatalog uCCake = new UCCakeKatalog(item);

                uCCake.Margin = new Thickness(10);
                CakesList.Children.Add(uCCake);
            }
        }
    }
}
