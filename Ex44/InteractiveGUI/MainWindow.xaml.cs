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

namespace InteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private readonly Controller controller = Controller.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPerson(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();
            UpdateChosen(sender, e);
        }

        private void UpdateChosen(object sender, RoutedEventArgs e)
        {
            if (controller.CurrentPerson is null)
            {
                FirstName.Text = string.Empty;
                LastName.Text = string.Empty;
                Age.Text = string.Empty;
                TelephoneNo.Text = string.Empty;

                FirstName.IsEnabled = false;
                LastName.IsEnabled = false;
                Age.IsEnabled = false;
                TelephoneNo.IsEnabled = false;

                DeletePerson.IsEnabled = false;
            }
            else
            {
                FirstName.Text = controller.CurrentPerson.FirstName;
                LastName.Text = controller.CurrentPerson.LastName;
                Age.Text = controller.CurrentPerson.Age.ToString();
                TelephoneNo.Text = controller.CurrentPerson.TelephoneNo;

                FirstName.IsEnabled = true;
                LastName.IsEnabled = true;
                Age.IsEnabled = true;
                TelephoneNo.IsEnabled = true;

                DeletePerson.IsEnabled = true;
            }

            PersonCount.Content = $"Person count {controller.PersonCount}";
            Indexed.Content = $"Index {controller.PersonIndex}";

            if (controller.PersonIndex >= controller.PersonCount - 1)
            {
                Up.IsEnabled = false;
            }
            else
            {
                Up.IsEnabled = true;
            }

            if (controller.PersonIndex <= 0)
            {
                Down.IsEnabled = false;
            }
            else
            {
                Down.IsEnabled = true;
            }
        }

        private void UpdateValues(object sender, TextChangedEventArgs e)
        {
            if (controller.CurrentPerson != null)
            {
                controller.CurrentPerson.FirstName = FirstName.Text;
                controller.CurrentPerson.LastName = LastName.Text;
                controller.CurrentPerson.TelephoneNo = TelephoneNo.Text;

                int.TryParse(Age.Text, out int age);
                controller.CurrentPerson.Age = age;
            }
        }

        private void DeletePersonClick(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
            UpdateChosen(sender, e);
        }

        private void UpClick(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            UpdateChosen(sender, e);
        }

        private void DownClick(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            UpdateChosen(sender, e);
        }
    }
}
