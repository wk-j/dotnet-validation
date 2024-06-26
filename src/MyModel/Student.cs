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
