using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using User.ClientService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static User.Global;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewCustomerPage : Page
    {
        StatusPage status;
        Customer customer;
        bool flag;
        public NewCustomerPage()
        {
            this.InitializeComponent();
        }

        public async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            if(txtCode.Text=="" || !Validation.CheckId(txtCode.Text))//בדיקת תז
            {
                txtEror.Text = "ת.ז. שגויה😕";
                flag = false;
            }
            //בדיקת  שם פרטי
            if (txtFirstName.Text == "" || !Validation.IsHebrew(txtFirstName.Text))
            {
                txtEror.Text = "שם פרטי שגוי😕";
                flag = false;
            }
            //בדיקת  שם משפחה
            if (txtLastName.Text == "" || !Validation.IsHebrew(txtLastName.Text))
            {
                txtEror.Text = "שם משפחה שגויה😕";
                flag = false;
            }
            
            //בדיקת מייל
            if(!Validation.IsMail(txtMail.Text))
            {
                txtEror.Text = "מייל שגוי😕";
                 flag = false;
            }
            if (flag)
            {
                if (status == StatusPage.Add)
                {
                    //מילוי של אוביקט בשדות מהעמוד
                    Customer c = new Customer();
                    FillObj(c);
                    await Global.proxy.AddNewCustomerAsync(c);
                    Global.currentCustomer = c;
                    this.Frame.Navigate(typeof(AfterConnectPage));
                }
                else if (status == StatusPage.Update)
                {
                    FillObj(customer);
                    await Global.proxy.UpdateCustomerAsync(customer);
                    //הודעה למשתמש שהעדכון בוצע
                    this.Frame.Navigate(typeof(MainPage));
                }
            }

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter != null)
            {
                customer = (Customer)e.Parameter;
                FillFields(customer);
                btnEnter.Content = "עדכן";
                status = StatusPage.Update;
            }
            else
            {
                status = StatusPage.Add;
            }
        }

        
        private void FillObj(ClientService.Customer c)
        {
            c.CustomerCode = Convert.ToInt32(txtCode.Text);
            c.FirstName = txtFirstName.Text;
            c.LastName = txtLastName.Text;
            c.CustomerPhone = txtPhone.Text;
            c.Gmail = txtMail.Text;
            c.CustomerPassword = txtPassword.Password;
        }
        private void FillFields(ClientService.Customer c)
        {
            txtCode.Text = c.CustomerCode.ToString();
            txtFirstName.Text = c.FirstName;
            txtLastName.Text = c.LastName;
            txtPhone.Text = c.CustomerPhone;
            txtMail.Text = c.Gmail;
            txtPassword.Password = c.CustomerPassword;
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BMenue_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AfterConnectPage));
        }
    }
}
