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

namespace BouncingBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Timer = new DispatcherTimer();

        Random Random = new Random();

        int speedX = 3;
        int speedY = 3;


        public MainWindow()
        {
          
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Tick);

            //Vi bestämmer hur ofta Timer_Tick ska anropas
            Timer.Interval = TimeSpan.FromMilliseconds(1);
            Timer.Start();
            Image img = new Image();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            MoveBall();
        }

        private void MoveBall()
        {
            double fromTop = Canvas.GetTop(Ball);
            double fromLeft= Canvas.GetLeft(Ball);

            fromTop += speedY;
            fromLeft += speedX;

            //om avståndet till toppen är mindre än 25 eller större än 340
            //Så ska vi byta riktning men här slumpar vi även en ny vinkel!
            if(fromTop<25 )
            {
                speedY = Random.Next(1, 5);
                fromTop +=speedY;
            }
            else if (fromTop > 360)
            {
                speedY = -Random.Next(1, 5);
                fromTop += speedY;
            }

            //Om avståndet från vänster är mindre än 50 eller större än 685
            //Så ska vi byta riktning från vänster
            if(fromLeft<50 | fromLeft > 705)
            {
                speedX = -speedX;
                fromLeft += speedX;
            }
            Canvas.SetLeft(Ball, fromLeft);
            Canvas.SetTop(Ball, fromTop);
        }

        
    }
}
