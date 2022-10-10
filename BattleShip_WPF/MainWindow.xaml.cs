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
using System.Runtime;

namespace BattleShip_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BattleshipVM bs = new BattleshipVM();
       
        public MainWindow()
        {
            DataContext = bs;
            InitializeComponent();
        }

        private void btn_Start(object sender, RoutedEventArgs e)
        {
            bs.Start();
        }

        private void btn_Stop(object sender, RoutedEventArgs e)
        {
            bs.Stop();
        }
    }
}
