using System.ComponentModel.DataAnnotations;

namespace MyModel;

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
