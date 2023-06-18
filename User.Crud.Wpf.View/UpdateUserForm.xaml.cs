using System;
using System.Windows;
using User.Crud.Wpf.Utilities.Event;
using User.Crud.Wpf.ViewModel;
using User.Crud.Wpf.ViewModel.Models;

namespace User.Crud.Wpf.View
{
    /// <summary>
    /// Interaction logic for UpdateUserForm.xaml
    /// </summary>
    public partial class UpdateUserForm : Window
    {
        private readonly UserViewModel _userViewModel;

        private MainPageGridUser _mainPageGridUser;

        public UpdateUserForm(UserViewModel userViewModel)
        {
            InitializeComponent();
            _userViewModel = userViewModel ?? throw new ArgumentNullException(nameof(userViewModel));
        }

        public void InitializeFromMainPage(MainPageGridUser mainPageGridUser)
        {
            _mainPageGridUser = mainPageGridUser;

            var user = _userViewModel.GetUser(mainPageGridUser.UserId);

            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtCountry.Text = user.Country;
        }
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userForUpdate = new UserForUpdate
                {
                    UserId = _mainPageGridUser.UserId,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Country = txtCountry.Text
                };

                _userViewModel.UpdateUser(userForUpdate);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
