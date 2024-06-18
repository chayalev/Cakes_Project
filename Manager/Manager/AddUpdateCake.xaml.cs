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
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using System.ServiceModel;
using static Manager.Global;
using System.Threading.Tasks;




// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddUpdateCake : Page
    {
        StatusPage status;
        StorageFile file;
        CakeDesserts cakeDessert;
        bool flag;
        public AddUpdateCake()
        {
            this.InitializeComponent();
        }
        public async void btnOK_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            //בדיקת שם
            //if (txtCakeName.Text == "" || !Validation.IsHebrew(txtCakeName.Text))
            //{
            //    txtEror.Text = "שם עוגה שגוי😕";
            //    flag = false;
            //}
              //בדיקת  מחיר
            if (txtCakePrice.Text == "" || !Validation.IsNum(txtCakePrice.Text))
            {
                txtEror.Text = "מחיר שגוי😕";
                flag = false;
            }
            if (flag)
            {
                if (status == StatusPage.Add)
                {
                    CakeDesserts c = new CakeDesserts();
                    await FillObj(c);
                    await Global.proxy.AddNewCakeDessertsAsync(c);
                    var stream = await file.OpenStreamForReadAsync();
                    byte[] bytes = new byte[(int)stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                }
                else if (status == StatusPage.Update)
                {
                    await FillObj(cakeDessert);
                    await Global.proxy.UpdateCakeDessertAsync(cakeDessert);
                }
                this.Frame.Navigate(typeof(CakeDessertPage));
            }
        }
             protected async override void OnNavigatedTo(NavigationEventArgs e)
           {
            cmbCategory.ItemsSource = await Global.proxy.GetAllCategoriesAsync();
            if (e.Parameter != null)
            {
                cakeDessert = (CakeDesserts)e.Parameter;
                FillFields(cakeDessert);
                btnOK.Content = "עדכן";
                status = StatusPage.Update;
            }
            else
            {
                status = StatusPage.Add;
            }
         }


        private async Task FillObj(CakeDesserts c)
        {
            c.CakeCode=await Global.proxy.GetNextCakeKeyAsync();
            c.CakeName = txtCakeName.Text;
            c.CakePrice = Convert.ToInt32(txtCakePrice.Text);
            c.CakeDetails = txtCakeDetails.Text;
            c.CakeCategory = (CakesCategory)cmbCategory.SelectedValue;
            if(file != null)
               c.CakePicture = file.Name;
            if (IsDairy.IsChecked == true)
                c.IsDairy = true;
            if (IsDairy.IsChecked == false)
                c.IsDairy = false;
            
        }
        private async void FillFields(CakeDesserts c)
        {
            txtCakeDetails.Text = c.CakeDetails;
            txtCakeName.Text = c.CakeName;
            txtCakePrice.Text = c.CakePrice.ToString();
            IsDairy.IsChecked = c.IsDairy;
            cmbCategory.SelectedItem= cmbCategory.Items.First(x=>((CakesCategory)x).CategoryCode==c.CakeCategory.CategoryCode);
            byte[] picArr = await Global.proxy.GetImageAsync(c.CakePicture);
            BitmapImage image = new BitmapImage();
            ImageConvert.ConvertByteArrayToImage(picArr, image);
            imgCake.Source = image;
            
        }

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker folder = new FileOpenPicker();
            folder.ViewMode = PickerViewMode.Thumbnail;
            folder.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            folder.FileTypeFilter.Add(".jpg");
            folder.FileTypeFilter.Add(".bmp");

            file = await folder.PickSingleFileAsync();

            if (file != null)
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage im = new BitmapImage();
                    im.SetSource(fileStream);
                    imgCake.Source = im;
              
                }
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CakeDessertPage));
        }
    }

}
