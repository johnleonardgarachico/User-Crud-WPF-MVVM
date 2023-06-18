using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using User.Crud.Wpf.Utilities.Event;
using User.Crud.Wpf.Utilities.Interfaces;
using User.Crud.Wpf.ViewModel;
using User.Crud.Wpf.ViewModel.Models;

namespace User.Crud.Wpf.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private readonly IAbstractFactory<CreateUserForm> _addUserFactory;
        private readonly IAbstractFactory<UpdateUserForm> _updateUserFactory;
        private readonly UserViewModel _userViewModel;

        public MainPage(IAbstractFactory<CreateUserForm> addUserFactory, IAbstractFactory<UpdateUserForm> updateUserFactory,
            UserViewModel userViewModel)
        {
            InitializeComponent();
            _addUserFactory = addUserFactory;
            _updateUserFactory = updateUserFactory;
            _userViewModel = userViewModel;

            userGrid.ItemsSource = _userViewModel.MainPageGridUsers;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var addUserForm = _addUserFactory.Create();

            addUserForm.Show();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (userGrid.SelectedItem is null)
            {
                MessageBox.Show("Please select an item in the grid to delete", "Information", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            var dataItem = userGrid.SelectedItem as MainPageGridUser;

            var confirmDelete = MessageBox.Show($"Are you sure you want to remove User {dataItem!.Name}", 
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmDelete == MessageBoxResult.Yes)
            {
                try
                {
                    _userViewModel.RemoveUser(dataItem!.UserId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (userGrid.SelectedItem is null)
            {
                MessageBox.Show("Please select an item in the grid to update", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            var dataItem = userGrid.SelectedItem as MainPageGridUser;

            var updateUserForm = _updateUserFactory.Create();

            try
            {
                updateUserForm.InitializeFromMainPage(dataItem!);

                updateUserForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
