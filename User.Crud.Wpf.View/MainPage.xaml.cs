using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using User.Crud.Wpf.Utilities.Event;
using User.Crud.Wpf.Utilities.Interfaces;
using User.Crud.Wpf.ViewModel;

namespace User.Crud.Wpf.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private readonly IAbstractFactory<CreateUserForm> _addUserFactory;
        private readonly UserViewModel _userViewModel;
        private readonly ObservableCollection<UserGridDataItem> _userGridItems;

        public MainPage(IAbstractFactory<CreateUserForm> addUserFactory, UserViewModel userViewModel)
        {
            InitializeComponent();
            _addUserFactory = addUserFactory;
            _userViewModel = userViewModel;

            _userGridItems = new ObservableCollection<UserGridDataItem>();
            userGrid.ItemsSource = _userGridItems;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var addUserForm = _addUserFactory.Create();

            addUserForm.Show();

            addUserForm.MethodCompleted += AddUserMethodCompleted;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (userGrid.SelectedItem is null)
            {
                MessageBox.Show("Please select an item in the grid to delete", "Information", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            var dataItem = userGrid.SelectedItem as UserGridDataItem;

            var confirmDelete = MessageBox.Show($"Are you sure you want to remove User {dataItem!.Name}", 
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmDelete == MessageBoxResult.Yes)
            {
                _userViewModel.RemoveUser(dataItem!.UserId);
                _userGridItems.Remove(dataItem);
            }
        }

        private void AddUserMethodCompleted(object sender, MethodCompletedEventArgs e)
        {
            var addedUser = _userViewModel.Users.Last();

            var newItem = new UserGridDataItem
            {
                UserId = addedUser.UserId,
                Name = $"{addedUser.FirstName} {addedUser.LastName}"
            };

            _userGridItems.Add(newItem);
        }

        private class UserGridDataItem
        {
            public int UserId { get; set; }
            public string Name { get; set; }
        }
    }
}
