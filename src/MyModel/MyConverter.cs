using System;
using System.Collections.Generic;
using System.Linq;

namespace MyModel
{
    public static class MyConverter
    {
        public static List<Property> ToFlatFormat<T>(T obj)
        {
            var properties = typeof(T).GetProperties();
            var flatProperties = new List<Property>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                var flatProperty = new Property
                {
                    Name = property.Name,
                    Type = GetPropertyType(property.PropertyType),
                    StringValue = property.PropertyType == typeof(string) ? (string)value : null,
                    DateTimeValue = property.PropertyType == typeof(DateTime) ? (DateTime?)value : null,
                    IntValue = property.PropertyType == typeof(int) ? (int?)value : null
                };
                flatProperties.Add(flatProperty);
            }

            return flatProperties;
        }

        public static T FromFlatFormat<T>(List<Property> flatProperties) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();

            foreach (var flatProperty in flatProperties)
            {
                var property = properties.FirstOrDefault(p => p.Name == flatProperty.Name);
                if (property != null)
                {
                    object value = null;
                    switch (flatProperty.Type)
                    {
                        case PropertyType.QString:
                            value = flatProperty.StringValue;
                            break;
                        case PropertyType.QDateTime:
                            value = flatProperty.DateTimeValue;
                            break;
                        case PropertyType.QInt:
                            value = flatProperty.IntValue;
                            break;
                    }
                    property.SetValue(obj, value);
                }
            }

            return obj;
        }

        private static PropertyType GetPropertyType(Type type)
        {
            if (type == typeof(string)) return PropertyType.QString;
            if (type == typeof(DateTime)) return PropertyType.QDateTime;
            if (type == typeof(int)) return PropertyType.QInt;
            throw new ArgumentException("Unsupported property type");
        }
    }
}
