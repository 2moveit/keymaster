using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.Licensee;


namespace Keymaster.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISubscribeTo<LicenseeCreated>
    {
        public MainWindow()
        {
            InitializeComponent();
        }

 

        private Guid CreateGuid(string companyName)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(companyName));
                return new Guid(hash);
            }
        }

        private void btn_CreateLicensee_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CreateLicensee { Id = CreateGuid(tbx_LicenseeName.Text), CompanyName = tbx_LicenseeName.Text, Address = tbx_LicenseeAddress.Text };
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            string licensee = string.Empty;
            if (cbx_ContactLicensees.SelectedValue != null)
                licensee = cbx_ContactLicensees.SelectedValue.ToString();
            var cmd = new AddContact { Id = CreateGuid(licensee), ContactName = tbx_Contact.Text, Email = tbx_Email.Text };
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_AddLicense_Click(object sender, RoutedEventArgs e)
        {
            string licensee = string.Empty;
            if (cbx_LicenseLicensees.SelectedValue != null)
                licensee = cbx_LicenseLicensees.SelectedValue.ToString();
            var cmd = new ProvideLicense { Id = CreateGuid(licensee) , ProductCode = CreateGuid(tbx_ProductCode.Text) };
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_ActivateLicense_Click(object sender, RoutedEventArgs e)
        {
             string licensee = string.Empty;
            if (cbx_ActivationLicensees.SelectedValue != null)
                licensee = cbx_LicenseLicensees.SelectedValue.ToString();

            string productCode = string.Empty;
            if (cbx_ActivationProductCodes.SelectedValue != null)
                productCode = cbx_ActivationProductCodes.SelectedValue.ToString();
            var cmd = new ActivateLicense { Id = CreateGuid(licensee), RegistrationCode = CreateGuid(tbx_RegistrationCode.Text), ProductCode = new Guid(productCode) };
            Domain.Dispatcher.SendCommand(cmd);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Domain.Setup(this);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbl_LicenseeDetail.Text = Domain.LicenseeQueries.DetailsForLicensee(cbx_Licensees.SelectedValue.ToString()).ToString();
        }

        public void Handle(LicenseeCreated e)
        {
            IList<string> licensees = Domain.LicenseeQueries.Licensees();
            cbx_Licensees.ItemsSource = licensees;
            cbx_ContactLicensees.ItemsSource = licensees;
            cbx_LicenseLicensees.ItemsSource = licensees;
            cbx_ActivationLicensees.ItemsSource = licensees;
        }

        private void cbx_ActivationLicensees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              string licensee = string.Empty;
            if (cbx_ActivationLicensees.SelectedValue != null)
                licensee = cbx_LicenseLicensees.SelectedValue.ToString();
            cbx_ActivationProductCodes.ItemsSource = Domain.LicenseeQueries.ProvidedProductCodes(CreateGuid(licensee));
        }
    }
}
