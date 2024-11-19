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
    /// Логика взаимодействия для koh.xaml
    /// </summary>
    public partial class koh : Window
    {
        public koh()
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
            if (int.TryParse(Counttb.Text, out int kol) && kol > 0 && kol < 7) DrawKochCurve(300, 250, 700, 250, kol, color);
        }

        private void DrawKochCurve(double x1, double y1, double x2, double y2, int level, string color)
        {
            try
            {
                if (level == 0)
                {
                    Line line = new Line
                    {
                        X1 = x1,
                        Y1 = y1,
                        X2 = x2,
                        Y2 = y2,
                        Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(color),
                        StrokeThickness = 1
                    };

                    canv.Children.Add(line);
            }
                else
            {
                double dx = x2 - x1;
                    double dy = y2 - y1;

                    double xA = x1 + dx / 3;
                    double yA = y1 + dy / 3;
                    double xB = x1 + 2 * dx / 3;
                    double yB = y1 + 2 * dy / 3;

                    double xC = (x1 + x2) / 2 - Math.Sqrt(3) * (y1 - y2) / 6;
                    double yC = (y1 + y2) / 2 - Math.Sqrt(3) * (x2 - x1) / 6;

                    DrawKochCurve(x1, y1, xA, yA, level - 1, color);

                    DrawKochCurve(xA, yA, xC, yC, level - 1, color);
                    DrawKochCurve(xC, yC, xB, yB, level - 1, color);
                    DrawKochCurve(xB, yB, x2, y2, level - 1, color);
                }
            }
            catch { }
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
        private void BackMain(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.Show();
        }
    }
}
