using System;
using System.Windows.Threading;

namespace BattleShip_WPF
{
    public partial class MainWindow
    {
        class BattleshipVM : ViewModelBase
        {
            DispatcherTimer timer;
            DateTime starTime;
            string time ="";
            public CellVM[][] OurMap { get; private set; }
            public CellVM[][] EnemyMap { get; private set; }
            public string Time { 
                get =>time; 
                private set=> Set(ref time, value); 
            }
            public BattleshipVM()
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(100);  //задаем интервал в миллисекундах
                timer.Tick += Timer_Tick;
                OurMap = MapFabrica();
                EnemyMap = MapFabrica();
                
            }
            CellVM[][] MapFabrica()
            {
                var map = new CellVM[10][];
                for (int i = 0; i < 10; i++)
                {
                    map[i] = new CellVM[10];
                    for (int j = 0; j < 10; j++)
                    {
                        map[i][j] = new CellVM();
                    }
                }
                return map;
            }
    private void Timer_Tick(object sender, EventArgs e)
            {
                var now = DateTime.Now;
                var dt = now - starTime;
                Time = dt.ToString(@"mm\:ss");
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
    }
}
