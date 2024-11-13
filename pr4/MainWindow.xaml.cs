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

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void kantorClick(object sender, RoutedEventArgs e)
        {
            kantor k = new kantor();
            this.Close();
            k.Show();
        }

        private void triangleClick(object sender, RoutedEventArgs e)
        {
            triangle t = new triangle();
            this.Close();
            t.Show();
        }

        private void RugClick(object sender, RoutedEventArgs e)
        {
            rug r = new rug();
            this.Close();
            r.Show();
        }

        private void KohClick(object sender, RoutedEventArgs e)
        {
            koh k = new koh();
            this.Close();
            k.Show();
        }

        private void treeClick(object sender, RoutedEventArgs e)
        {
            tree t = new tree();
            this.Close();
            t.Show();
        }
    }
}
