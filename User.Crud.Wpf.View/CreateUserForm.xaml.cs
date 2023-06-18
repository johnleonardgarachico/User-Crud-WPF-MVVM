using System;
using System.Windows;
using User.Crud.Wpf.Utilities.Event;
using User.Crud.Wpf.ViewModel;
using User.Crud.Wpf.ViewModel.Models;

namespace User.Crud.Wpf.View
{
    /// <summary>
    /// Interaction logic for CreateUserForm.xaml
    /// </summary>
    public partial class CreateUserForm : Window
    {
        private readonly UserViewModel _userViewModel;

        public event MethodCompletedEventHandler MethodCompleted;

        public CreateUserForm(UserViewModel userViewModel)
        {
            InitializeComponent();
            _userViewModel = userViewModel ?? throw new ArgumentNullException(nameof(userViewModel));
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userForAdding = new UserForAdding
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Country = txtCountry.Text
                };

                _userViewModel.AddUser(userForAdding);

                this.Close();

                NotifyMethodCompleted(nameof(buttonAdd_Click));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void NotifyMethodCompleted(string methodName)
        {
            MethodCompleted?.Invoke(this, new MethodCompletedEventArgs { MethodName = methodName });
        }
    }
}
