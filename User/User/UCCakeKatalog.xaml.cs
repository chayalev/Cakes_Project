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
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace User
{
    
    public sealed partial class UCCakeKatalog : UserControl
    {
        int c = 0;
        public CakeDesserts cake;
        public UCCakeKatalog()
        {
            this.InitializeComponent();
        }

        public int Amount()
        {
            return c;
        }
        public UCCakeKatalog(CakeDesserts cake)
        {
            this.InitializeComponent();
            this.cake = cake;
            FillFields();
            txtAmount.Text = "0";
            if (Global.currentCustomer == null)
            { 
                spButtons.Visibility = Visibility.Collapsed;
            }

        }
        private async void FillFields()
        {
            cakeCode.Text = cake.CakeCode.ToString();
            cakeName.Text = cake.CakeName.ToString();
            cakePrice.Text = cake.CakePrice.ToString();
            cakeDetails.Text = cake.CakeDetails.ToString();
            byte[] picArr = await Global.proxy.GetImageAsync(cake.CakePicture);
             BitmapImage image = new BitmapImage();
            ImageConvert.ConvertByteArrayToImage(picArr, image);
            cakeImg.Source = image;

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
           
                c++;
                txtAmount.Text = c.ToString();
         }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (c != 0)
            {
                c--;
                txtAmount.Text = c.ToString();
            }
           
        }
    }
}
