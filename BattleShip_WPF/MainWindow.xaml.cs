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
using System.Windows.Threading;
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

        class BattleshipVM: ViewModelBase
        {
            DispatcherTimer timer;
            DateTime starTime;
            string time ="";
            public string Time { 
                get =>time; 
                private set=> Set(ref time, value); 
            }
            public BattleshipVM()
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(100);  //задаем интервал в миллисекундах
                timer.Tick += Timer_Tick;
            }

            private void Timer_Tick(object sender, EventArgs e)
            {
                var now = DateTime.Now;
                var dt = now - starTime;
               Time = $"{(int)dt.TotalMinutes}:{dt.Seconds.ToString("D2")} "  + dt.ToString(@"mm\:ss");
                    }

            public void Start()
            {
                starTime = DateTime.Now;
                timer.Start();
            }
            public void Stop()
            {
                timer.Stop();
            }
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
