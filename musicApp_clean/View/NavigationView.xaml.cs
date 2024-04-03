using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using musicApp_clean.Infrastructure.EntityFramework.Model;
using musicApp_clean.UI.Services.Implementation;
using musicApp_clean.UI.Services.Interface;
using musicApp_clean.UI.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace musicApp_clean.UI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NavigationView : Window
    {
        public NavigationView()
        {
            InitializeComponent();
        }
    }
}