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
            AddTextBox();
            AddTextBox();
            AddTextBox();
            AddTextBox();
        }

        public TextBox CreateTextBox(string text)
        {
            Thickness thick = new Thickness
            {
                Bottom = 10
            };

            TextBox txtbx = new TextBox
            {
                Height = 23,
                TextWrapping = TextWrapping.Wrap,
                Margin = thick,
                Text = text
            };

            return txtbx;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            foreach (TextBox txtBx in TextBoxes.Children)
            {
                txtBx.Clear();
            }
        }

        private void ScrollDown(object sender, RoutedEventArgs e)
        {
            string lastTbTxt = ((TextBox)TextBoxes.Children[TextBoxes.Children.Count - 1]).Text;

            for (int i = TextBoxes.Children.Count - 1; i >= 0; i--)
            {
                TextBox txtBx = (TextBox)TextBoxes.Children[i];

                if (i == 0)
                {
                    txtBx.Text = lastTbTxt;
                    return;
                }

                TextBox txtBxNext = (TextBox)TextBoxes.Children[i - 1];

                txtBx.Text = txtBxNext.Text;
            }
        }

        private void ScrollUp(object sender, RoutedEventArgs e)
        {
            string lastTbTxt = ((TextBox)TextBoxes.Children[0]).Text;

            for (int i = 0; i < TextBoxes.Children.Count; i++)
            {
                TextBox txtBx = (TextBox)TextBoxes.Children[i];

                if (i == TextBoxes.Children.Count - 1)
                {
                    txtBx.Text = lastTbTxt;
                    return;
                }

                TextBox txtBxNext = (TextBox)TextBoxes.Children[i + 1];

                txtBx.Text = txtBxNext.Text;
            }
        }

        private void AddTextBox(object sender, RoutedEventArgs e)
        {
            AddTextBox();
        }

        private void AddTextBox()
        {
            TextBoxes.Children.Add(CreateTextBox("Textbox " + (TextBoxes.Children.Count + 1)));
        }

        private void RemoveTextBox(object sender, RoutedEventArgs e)
        {
            TextBoxes.Children.Remove(TextBoxes.Children[TextBoxes.Children.Count - 1]);
        }
    }
}
