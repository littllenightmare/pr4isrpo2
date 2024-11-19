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
    /// Логика взаимодействия для rug.xaml
    /// </summary>
    public partial class rug : Window
    {
        public rug()
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
            if (int.TryParse(Counttb.Text, out int kol) && kol > 0 && kol <= 5) DrawSierpinskiCarpet(400, 100, 300, kol, color);
        }
        private void DrawSierpinskiCarpet(double x, double y, double size, int level, string color)
        {
            if (level == 0)
            {
                Rectangle rectangle = new Rectangle
                {
                    Width = size,
                    Height = size,
                    Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(color)
                };

                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);
                canv.Children.Add(rectangle);
            }
            else
            {
                double newSize = size / 3;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != 1 || j != 1)
                        {
                            DrawSierpinskiCarpet(x + i * newSize, y + j * newSize, newSize, level - 1, color);
                        }
                    }
                }
            }
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
