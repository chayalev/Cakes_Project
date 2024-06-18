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
using System.Threading.Tasks;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace User
{
    public sealed partial class UCDesignCake : UserControl
    {
        public DesignedPhotoGallery designCake;
        public UCDesignCake()
        {
            this.InitializeComponent();
        }
        public UCDesignCake(DesignedPhotoGallery designedPhoto)
        {
            this.InitializeComponent();
            designCake= designedPhoto;
            txtDetails.Text= designedPhoto.Details;
            txtPrice.Text = designedPhoto.Price.ToString() +" ש''ח";
       

        }
        private async Task FillFields()
        {
            byte[] picArr = await Global.proxy.GetImageAsync(designCake.Picture);
            BitmapImage image = new BitmapImage();
            ImageConvert.ConvertByteArrayToImage(picArr, image);
            imgPic.Source = image;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectedCakeKatalog(this);
           btnSelect.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 232, 0, 135));
        }

        public delegate void SelectCake(UCDesignCake uCCake);
        public event SelectCake SelectedCakeKatalog;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           await FillFields();
        }
    }
}
