namespace MyModel;

public enum PropertyType
{
    QString,
    QDateTime,
    QInt
}

public class Property
{
    public string Name { get; set; }
    public PropertyType Type { get; set; }
    public string? StringValue { get; set; }
    public DateTime? DateTimeValue { get; set; }
    public int? IntValue { get; set; }
}
