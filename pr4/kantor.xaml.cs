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
    /// Логика взаимодействия для kantor.xaml
    /// </summary>
    public partial class kantor : Window
    {
        public kantor()
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
            if (int.TryParse(Counttb.Text, out int kol) && kol > 0 && kol < 13) DrawCantorSet(250, 40, 700, kol, color);
        }

        private void DrawCantorSet(double x, double y, double length, int level, string color)
        {
            try
            {
                if (level == 0)
                    return;

                DrawLine(x, y, length, color);

                DrawCantorSet(x, y + 30, length / 3, level - 1, color);
                DrawCantorSet(x + 2 * length / 3, y + 30, length / 3, level - 1, color);
            }
            catch { }
            }

        private void DrawLine(double x, double y, double length, string color)
        {
            Line line = new Line
            {
                X1 = x,
                Y1 = y,
                X2 = x + length,
                Y2 = y,
                Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(color),
                StrokeThickness = 5
            };
            canv.Children.Add(line);
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
