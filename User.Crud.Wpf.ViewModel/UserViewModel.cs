using User.Crud.Wpf.ViewModel.Converter;
using User.Crud.Wpf.ViewModel.Models;

namespace User.Crud.Wpf.ViewModel
{
    public class UserViewModel
    {
        public readonly IList<Model.User> Users;

        public UserViewModel()
        {
            Users = new List<Model.User>();
        }

        public void AddUser(UserForAdding userForAdding)
        {
            userForAdding.UserId = Users.Count + 1;

            var convertedUser = UserConverter.ConvertUserForAddingToUser(userForAdding);

            Users.Add(convertedUser);
        }
    }
}