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
using User.Crud.Wpf.ViewModel.Models;
using User.Crud.Wpf.ViewModel;

namespace User.Crud.Wpf.View
{
    /// <summary>
    /// Interaction logic for ReadUserForm.xaml
    /// </summary>
    public partial class ReadUserForm : Window
    {
        private readonly UserViewModel _userViewModel;

        private MainPageGridUser _mainPageGridUser;

        public ReadUserForm(UserViewModel userViewModel)
        {
            InitializeComponent();
            _userViewModel = userViewModel;
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
            this.Close();
        }
    }
}
