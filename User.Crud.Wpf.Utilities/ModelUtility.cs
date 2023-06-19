using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace User.Crud.Wpf.Utilities
{
    public static class ModelUtility
    {
        public static bool IsValid(object instance)
        {
            if (instance == null)
            {
                return false;
            }

            var validationContext = new ValidationContext(instance);
            var validationResults = new List<ValidationResult>();

            var test = Validator.TryValidateObject(instance, validationContext, validationResults, true);

            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }
    }
}
