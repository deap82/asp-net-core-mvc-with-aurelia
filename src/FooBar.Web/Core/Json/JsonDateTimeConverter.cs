using System.Globalization;
using Newtonsoft.Json.Converters;

namespace FooBar.Web.Core.Json
{
    public class JsonDateTimeConverter : IsoDateTimeConverter
    {
        public JsonDateTimeConverter()
        {
            Culture = new CultureInfo("sv-SE"); //Force ISO 8601
            DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm";
        }
    }
}