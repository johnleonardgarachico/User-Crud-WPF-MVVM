using System.Collections.ObjectModel;
using User.Crud.Wpf.ViewModel.Converter;
using User.Crud.Wpf.ViewModel.Models;

namespace User.Crud.Wpf.ViewModel
{
    public class UserViewModel
    {
        private readonly IList<Model.User> Users;

        public ObservableCollection<MainPageGridUser> MainPageGridUsers;

        public UserViewModel()
        {
            Users = new List<Model.User>();
            MainPageGridUsers = new ObservableCollection<MainPageGridUser>();
        }

        public Model.User GetUser(int userId)
        {
            var user = Users.FirstOrDefault(x => x.UserId == userId);

            if (user is null)
            {
                throw new InvalidOperationException($"UserID {userId} could not be found in User storage!");
            }

            return user;
        }

        public void AddUser(UserForAdding userForAdding)
        {
            try
            {
                userForAdding.UserId = Users.Count + 1;

                var convertedUser = UserConverter.ConvertUserForAddingToUser(userForAdding);

                Users.Add(convertedUser);

                var mainPageGridUser = new MainPageGridUser
                {
                    UserId = convertedUser.UserId,
                    Name = $"{convertedUser.FirstName} {convertedUser.LastName}"
                };

                MainPageGridUsers.Add(mainPageGridUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveUser(int userId)
        {
            var userForRemoving = Users.FirstOrDefault(x => x.UserId == userId);

            if (userForRemoving is null)
            {
                throw new InvalidOperationException($"UserID {userId} could not be found in User storage!");
            }

            Users.Remove(userForRemoving);

            var mainPageGridUser = MainPageGridUsers.First(x => x.UserId == userId);

            MainPageGridUsers.Remove(mainPageGridUser);
        }

        public void UpdateUser(UserForUpdate userForUpdate)
        {
            try
            {
                var storedUser = Users.FirstOrDefault(x => x.UserId == userForUpdate.UserId);

                if (storedUser is null)
                {
                    throw new InvalidOperationException($"User {userForUpdate.FirstName} {userForUpdate.LastName} could not be found in User storage!");
                }

                var position = Users.IndexOf(storedUser);

                var convertedUser = UserConverter.ConvertUserForUpdateToUser(userForUpdate);

                Users.Insert(position, convertedUser);
                Users.Remove(storedUser);

                var oldMainPageGridUser = MainPageGridUsers.FirstOrDefault(x => x.UserId == userForUpdate.UserId);

                if (oldMainPageGridUser is null)
                {
                    throw new InvalidOperationException($"User {userForUpdate.FirstName} {userForUpdate.LastName} could not be found in main page grid!");
                }

                var mainPageGridUserPosition = MainPageGridUsers.IndexOf(oldMainPageGridUser);

                var newMainPageGridUser = new MainPageGridUser
                {
                    UserId = convertedUser.UserId,
                    Name = $"{convertedUser.FirstName} {convertedUser.LastName}"
                };

                MainPageGridUsers.Insert(mainPageGridUserPosition, newMainPageGridUser);
                MainPageGridUsers.Remove(oldMainPageGridUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}