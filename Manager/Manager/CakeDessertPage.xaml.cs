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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CakeDessertPage : Page
    {
        CakesCategory c;
        StatusPage status;
        public CakeDessertPage()
        {
            this.InitializeComponent();
        }

        //private void btnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(AddUpdateCake),(CakeDesserts)((Button)sender).DataContext);
        //}
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lvCakesDesserts.ItemsSource = await Global.proxy.GetAllCakeDessertsAsync();
            lvCategories.ItemsSource = await Global.proxy.GetAllCategoriesAsync();
        }

        private void btnNewCakes_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddUpdateCake));
        }

        private async void btnEdit1_Click(object sender, RoutedEventArgs e)
        {
            c =(CakesCategory)((Button)sender).DataContext;
            txtCategoryName.Text = c.CategoryName;
            btnOK.Content = "עדכן";
            status = StatusPage.Update;
         }

        private async void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (status == StatusPage.Add)
            {
               CakesCategory c = new CakesCategory();
               c.CategoryCode = await Global.proxy.GetNextCategoryKeyAsync() ;
                c.CategoryName=txtCategoryName.Text;    
                await Global.proxy.AddNewCategoryAsync(c);
                
            }
            else if (status == StatusPage.Update)
            {
                c.CategoryName = txtCategoryName.Text;
                await Global.proxy.UpdateCategoryAsync(c);
            }
            lvCategories.ItemsSource = await Global.proxy.GetAllCategoriesAsync();
           
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            status = StatusPage.Add;
            txtCategoryName.Text = "";
        }
    }
}
