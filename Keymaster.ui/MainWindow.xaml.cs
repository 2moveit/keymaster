using System;
using System.Collections.Generic;
using System.Linq;
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
using YourDomain.Something;

namespace Keymaster.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_CreateLicensee_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CreateCustomer {Id = Guid.NewGuid(), What = "New"};
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CreateCustomer { Id = Guid.NewGuid(), What = "New" };
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_AddLicense_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CreateCustomer { Id = Guid.NewGuid(), What = "New" };
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_AddActivation_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CreateCustomer { Id = Guid.NewGuid(), What = "New" };
            Domain.Dispatcher.SendCommand(cmd);
        }

        private void btn_AddVersion_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CreateCustomer { Id = Guid.NewGuid(), What = "New" };
            Domain.Dispatcher.SendCommand(cmd);
        }

    }
}
