using User.Crud.Wpf.ViewModel.Models;

namespace User.Crud.Wpf.ViewModel.Converter
{
    public static class UserConverter
    {
        public static Model.User ConvertUserForAddingToUser(UserForAdding userForAdding)
        {
            var convertedUser = new Model.User(userForAdding.UserId, userForAdding.FirstName, 
                userForAdding.LastName, userForAdding.Country);

            return convertedUser;
        }

        public static Model.User ConvertUserForUpdateToUser(UserForUpdate userForUpdate)
        {
            var convertedUser = new Model.User(userForUpdate.UserId, userForUpdate.FirstName,
                userForUpdate.LastName, userForUpdate.Country);

            return convertedUser;
        }
    }
}
