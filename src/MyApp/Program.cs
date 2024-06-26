
using System.Text.Json;
using MyModel;

void Vaidate<T>(T obj)
{
    var (isValid, result) = MyValidator.ValidateObject(obj);
    Console.WriteLine(isValid);
    foreach (var item in result)
    {
        Console.WriteLine(item.ErrorMessage);
    }
}

Student student = new()
{
    FirstName = "wk",
    Age = 10,
    Email = "@gmail.com"
};

var property = MyConverter.ToFlatFormat(student);

var propertyJson = JsonSerializer.Serialize(property, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(propertyJson);

var obj = MyConverter.FromFlatFormat<Student>(property);
var objJson = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(objJson);
