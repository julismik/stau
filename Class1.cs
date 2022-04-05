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
        public double Radius { get; private set; }
        public double Winkel { get; private set; }
        public double Winkelgeschwindigkeit { get; private set; }

        // Konstruktor 
        public Auto(Canvas Zeichenflache)
        {
            PositionX = rnd.Next(0, Convert.ToInt32(Zeichenflache.Width));
            PositionY = rnd.Next(0, Convert.ToInt32(Zeichenflache.Height));
            GeschwindigkeitX = (400 * rnd.NextDouble() + 800) * rnd.Next(-1,2);
            GeschwindigkeitY = (800 + 400 * rnd.NextDouble()) * rnd.Next(-1,2);


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
        public void Bewegen(TimeSpan interval, Canvas Zeichenflache)
        {
            PositionX += GeschwindigkeitX * interval.TotalMinutes;
            PositionY += GeschwindigkeitY * interval.TotalMinutes;
            if (PositionX > Zeichenflache.ActualWidth)
            {

                PositionX = Zeichenflache.ActualWidth;
            }
            else if (PositionX < 0)
            {
                PositionX = Zeichenflache.ActualWidth;
            }
            else if (PositionY > Zeichenflache.ActualHeight)
            {
                PositionY = 0;
            }
            else if(PositionY < 0)
            {
                PositionY = Zeichenflache.ActualHeight;
            }



        }
        public void Beschleunigung (double beschleunigung)
        {
            PositionX += GeschwindigkeitX + beschleunigung;
            PositionY += GeschwindigkeitY + beschleunigung ;
        }
    
    }
}
