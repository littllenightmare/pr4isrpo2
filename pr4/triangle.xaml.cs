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
using System.Windows.Shapes;

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для triangle.xaml
    /// </summary>
    public partial class triangle : Window
    {
        public triangle()
        {
            InitializeComponent();
        }

        private void DrawAgain(object sender, TextChangedEventArgs e)
        {
            canv.Children.Clear();
            string color = "";
            if (green.IsChecked == true) color = "Green";
            if (red.IsChecked == true) color = "Red";
            if (blue.IsChecked == true) color = "Blue";
            if (int.TryParse(Counttb.Text, out int kol) && kol > 0 && kol < 5) DrawAgainColor(5, new Point(300, 50), new Point(50, 550), new Point(550, 550), kol, color);
        }

        private void CheckChanged(object sender, RoutedEventArgs e)
        {
            if (e.Source == green && green.IsChecked == true)
            {
                red.IsChecked = false;
                blue.IsChecked = false;
            }
            if (e.Source == red && red.IsChecked == true)
            {
                green.IsChecked = false;
                blue.IsChecked = false;
            }
            if (e.Source == blue && blue.IsChecked == true)
            {
                red.IsChecked = false;
                green.IsChecked = false;
            }
        }
        private void DrawAgainColor(int depth, Point top, Point left, Point right, int kol, string color)
        {
            try
            {
                if (kol != 0)
                {
                    if (depth == 0)
                    {
                        DrawTriangle(top, left, right, color);
                    }
                    else
                    {
                        var midLeft = Midpoint(top, left);
                        var midRight = Midpoint(top, right);
                        var midBottom = Midpoint(left, right);
                        kol--;

                        DrawAgainColor(depth - 1, top, midLeft, midRight, kol, color);
                        DrawAgainColor(depth - 1, left, midLeft, midBottom, kol, color);
                        DrawAgainColor(depth - 1, right, midRight, midBottom, kol, color);
                    }
                }
            }
            catch { }
        }

        private Point Midpoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private void DrawTriangle(Point p1, Point p2, Point p3, string color)
        {
            Polygon triangle = new Polygon
            {
                Points = new PointCollection { p1, p2, p3 },
                Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(color)
            };
            canv.Children.Add(triangle);
        }

        private void BackMain(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.Show();
        }
    }
}
