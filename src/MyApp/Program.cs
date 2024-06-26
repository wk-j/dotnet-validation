
using MyModel;

Student student = new()
{
    FirstName = "wk",
    Age = 10,
    Email = "@gmail.com"
};

var (isValid, result) = MyValidator.ValidateObject(student);

Console.WriteLine(isValid);

foreach (var item in result)
{
    Console.WriteLine(item.ErrorMessage);
}
