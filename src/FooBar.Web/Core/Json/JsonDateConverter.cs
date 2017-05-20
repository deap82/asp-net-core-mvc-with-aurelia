using System.Globalization;
using Newtonsoft.Json.Converters;

namespace FooBar.Web.Core.Json
{
    public class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter()
        {
            Culture = new CultureInfo("sv-SE"); //Force ISO 8601
            DateTimeFormat = "d";
        }
    }
}