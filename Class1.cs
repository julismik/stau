using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace stau
{
    class Auto
    {
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }
        public double GeschwindigkeitX { get; private set; }
        public double GeschwindigkeitY { get; private set; }
        private static Random rnd = new Random();

        // Konstruktor 
        public Auto(Canvas Zeichenflachei)
        {
            PositionX = Zeichenflachei.ActualWidth * rnd.NextDouble();
            PositionY = Zeichenflachei.ActualHeight * rnd.NextDouble();
            GeschwindigkeitX = 8 + 40 * rnd.NextDouble();
            GeschwindigkeitY = 8 + 40 * rnd.NextDouble();


        }
        //Methoden 
        public void Zeichne(Canvas Zeichenflache)
        {
            Ellipse e = new Ellipse();
            e.Width = 10;
            e.Height = 10;
            e.Fill = Brushes.Aquamarine;
            Canvas.SetLeft(e, PositionX);
            Canvas.SetTop(e, PositionY );

            Zeichenflache.Children.Add(e);
        }
        public void Bewegen(TimeSpan interval)
        {
            PositionX += GeschwindigkeitX * interval.TotalSeconds;
            PositionY += GeschwindigkeitY * interval.TotalSeconds;


        }
    
    }
}
