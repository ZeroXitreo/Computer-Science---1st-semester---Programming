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

namespace SimpleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
        }

        private void ScrollDown(object sender, RoutedEventArgs e)
        {
            string tb4 = TextBox4.Text;

            TextBox4.Text = TextBox3.Text;
            TextBox3.Text = TextBox2.Text;
            TextBox2.Text = TextBox1.Text;
            TextBox1.Text = tb4;
        }

        private void ScrollUp(object sender, RoutedEventArgs e)
        {
            string tb1 = TextBox1.Text;

            TextBox1.Text = TextBox2.Text;
            TextBox2.Text = TextBox3.Text;
            TextBox3.Text = TextBox4.Text;
            TextBox4.Text = tb1;
        }
    }
}
