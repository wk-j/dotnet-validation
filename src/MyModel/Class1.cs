using System.ComponentModel.DataAnnotations;

namespace MyModel;

public class Student
{
    [Required]
    [MinLength(3)]
    public string FirstName { get; set; }
    public string MiddleName { set; get; }

    [Required]
    [MinLength(3)]
    public string LastName { get; set; }

    [Range(12, 40)]
    public int Age { set; get; }

    [EmailAddress]
    [Required]
    public string Email { set; get; }
}

public class Teacher
{
    [Required]
    public string FirstName { get; set; }

    public string MiddleName { set; get; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Degree { set; get; }

    [Range(30, 70)]
    public int Age { set; get; }
}


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
