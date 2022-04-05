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

namespace stau
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List <Auto> autos = new List<Auto> ();

        //Auto[] autos = new Auto[3];
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);
            timer.Start();
            timer.Tick += animiere;
            for ( int i = 0; i < 10; i++)
            {
                autos.Add(new Auto(Zeichenflache));
               //autos[i] = new Auto(Zeichenflache);
            }

            
        }

        private void animiere(object sender, EventArgs e)
        {
           Zeichenflache.Children.Clear();
           foreach(Auto item in autos)
            {
                item.Bewegen(timer.Interval, Zeichenflache);
                item.Zeichne(Zeichenflache);
            }

        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up )
            {
                autos.ForEach(x => x.Beschleunigung(180));
            }
            if (e.Key == Key.Down)
            {
                autos.ForEach(x => x.Beschleunigung(-180));
            }
        }

    }
}
