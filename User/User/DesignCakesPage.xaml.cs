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
using User.ClientService;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DesignCakesPage : Page
    {
        List<DesignedPhotoGallery> designedPhotoGalleries;
        DesignedPhotoGallery SelectdesignedPhoto;

        StorageFile file;
        Orders order;
        public DesignCakesPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            cmbBaseKind.ItemsSource = await Global.proxy.GetAllBaseKindAsync();
            cmbEvent.ItemsSource = await Global.proxy.GetAllEventsKindAsync();
            designedPhotoGalleries = await Global.proxy.GetAllDesignedPhotoGalleryAsync();
            foreach (var item in designedPhotoGalleries)
            {
                UCDesignCake uc = new UCDesignCake(item);
                uc.SelectedCakeKatalog += Uc_SelectedCakeKatalog;
                uc.Margin = new Thickness(10);
                gridKatalog.Children.Add(uc);
            }
           
            ShowChat();

        }
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            //הוספת הודעה
            Messages m = new Messages();
            m.MessageCode = await Global.proxy.GetNextMessagesKeyAsync();
            m.CustomerCode=Global.currentCustomer;
            m.IsCustomer = true;
            m.Topic = txtTyping.Text;
            await Global.proxy.AddNewMessagesAsync(m);

            ShowChat();
            txtTyping.Text = "";
        }
        private async void ShowChat()
        {
            Chat.Children.Clear();
            List<Messages> messages = await Global.proxy.GetMessagesByCustomerAsync(Global.currentCustomer);
            foreach (var item in messages)
            {
                Border b = new Border();
                b.Margin = new Thickness(5);
                TextBlock t = new TextBlock();
                t.TextWrapping = TextWrapping.Wrap;
                t.Text = item.Topic;
                b.Child = t;
                //מהלקוח
                if (item.IsCustomer)
                {
                    t.HorizontalAlignment = HorizontalAlignment.Right;
                    t.TextAlignment = TextAlignment.Right;
                    b.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(200, 240, 164, 164));

                    if (!item.IsRead)
                    {
                        //הדגשה
                        FontWeight w = new FontWeight();
                        w.Weight = 500;
                        t.FontWeight = w;
                    }
                }

                else//מהקונדיטורית
                {
                    t.HorizontalAlignment = HorizontalAlignment.Left;
                    t.TextAlignment = TextAlignment.Left;
                    b.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 8, 194, 232));
                    if (!item.IsRead)
                    {
                        //הדגשה
                        FontWeight w = new FontWeight();
                        w.Weight = 500;
                        t.FontWeight = w;
                    }
                }

                Chat.Children.Add(b);
            }
        }

        private async void txtTyping_GotFocus(object sender, RoutedEventArgs e)
        {
            await Global.proxy.ReadAllMessagesAsync(Global.currentCustomer);
            ShowChat();
        }


        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker folder = new FileOpenPicker();
            folder.ViewMode = PickerViewMode.Thumbnail;
            folder.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            folder.FileTypeFilter.Add(".jpg");
            folder.FileTypeFilter.Add(".bmp");
            
            file = await folder.PickSingleFileAsync();
            
            if(file!=null)
            {
                using(IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage im= new BitmapImage();
                    im.SetSource(fileStream);
                    imgCake.Source = im;
                    price.Text = (Convert.ToInt32(price.Text) + 30).ToString();
                }
            }
       
        }

        private async void cmbEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridKatalog.Children.Clear();
            if (cmbBaseKind.SelectedIndex != -1 && cmbEvent.SelectedIndex != -1)
            {
                designedPhotoGalleries = await Global.proxy.GetDesignedPhotoGalleriesByBaseKindAndEventAsync(((BaseKind)cmbBaseKind.SelectedItem).KindCode, ((EventKind)cmbEvent.SelectedItem).EventKindCode);
                foreach (var item in designedPhotoGalleries)
                {
                    UCDesignCake uc = new UCDesignCake(item);
                    uc.SelectedCakeKatalog += Uc_SelectedCakeKatalog;
                    uc.Margin = new Thickness(10);
                    gridKatalog.Children.Add(uc);
                }
            }
        }

        private void Uc_SelectedCakeKatalog(UCDesignCake uCCake)//ארוע שקורה כנלחץ על בחר ביוזר קונטרול
        {
            SelectdesignedPhoto = uCCake.designCake;
            price.Text = SelectdesignedPhoto.Price.ToString() ;

        }

        private async void cmbBaseKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridKatalog.Children.Clear();
            if (cmbBaseKind.SelectedIndex != -1 && cmbEvent.SelectedIndex != -1)
            {
                designedPhotoGalleries = await Global.proxy.GetDesignedPhotoGalleriesByBaseKindAndEventAsync(((BaseKind)cmbBaseKind.SelectedItem).KindCode, ((EventKind)cmbEvent.SelectedItem).EventKindCode);
                foreach (var item in designedPhotoGalleries)
                {
                    UCDesignCake uc = new UCDesignCake(item);
                    uc.SelectedCakeKatalog += Uc_SelectedCakeKatalog;
                    uc.Margin = new Thickness(10);
                    gridKatalog.Children.Add(uc);
                }
            }
        }

        private async void addToCart_Click(object sender, RoutedEventArgs e)
        {
            if (dateGoal.Date == null)
                txtEror.Text = "שכחת להכניס תאריך!!! בחר תאריך במהירות😊!";
            else
            {
                Orders o = new Orders();
                o.CakeExampleCode = SelectdesignedPhoto;
                o.Price = Convert.ToInt32(price.Text);
                o.Remarks = txtremarks.Text;
                o.CakeKind = SelectdesignedPhoto.BaseKind;
                o.StatusCode = await Global.proxy.GetStatusByCodeAsync(1);
                o.DateGoal = dateGoal.Date.Value.Date;
                Global.OrdersLst.Add(o);
                PicturesInCake pic = new PicturesInCake();
                if (file != null)
                {
                    pic.PictureFile = file.Name;
                    pic.OrderCode = o;
                    Global.PicturesInCakes.Add(pic);
                    var stream = await file.OpenStreamForReadAsync();
                    byte[] bytes = new byte[(int)stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    Global.lstPic.Add(bytes);
                }
                this.Frame.Navigate(typeof(NewOrderPage));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewOrderPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void dateGoal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txtEror.Text = "";
        }
    }
}
