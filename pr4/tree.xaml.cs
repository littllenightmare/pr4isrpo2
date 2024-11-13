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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для tree.xaml
    /// </summary>
    public partial class tree : Window
    {
        public tree()
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
            if (int.TryParse(Counttb.Text, out int kol) && kol > 0 && kol < 16) DrawAgainColor(500, 400, -90, kol, color);
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
        private void DrawAgainColor(double x1, double y1, double angle, int kol, string color)
        {
            try
            {
                if (kol != 0)
                {
                    double x2 = x1 + Math.Cos(angle * Math.PI / 180) * 2 * 10;
                    double y2 = y1 + Math.Sin(angle * Math.PI / 180) * 2 * 10;
                    Line line = new Line()
                    {
                        X1 = x1,
                        Y1 = y1,
                        X2 = x2,
                        Y2 = y2,
                        Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(color),
                        StrokeThickness = 2
                    };
                    line.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
                    canv.Children.Add(line);
                    kol--;
                    DrawAgainColor(x2, y2, angle - 20, kol, color);
                    DrawAgainColor(x2, y2, angle + 20, kol, color);
                }
            }
            catch { }
        }

        private void BackMain(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.Show();
        }
    }
}