using System.ComponentModel.DataAnnotations;

namespace MyModel;


public class MyValidator
{
    public static (bool, List<ValidationResult>) ValidateObject<T>(T obj)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(obj, null, null);
        var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
        return (isValid, validationResults);
    }
}
