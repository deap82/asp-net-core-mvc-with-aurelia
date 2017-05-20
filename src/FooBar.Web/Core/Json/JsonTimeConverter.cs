using System.Globalization;
using Newtonsoft.Json.Converters;

namespace FooBar.Web.Core.Json
{
    public class JsonTimeConverter : IsoDateTimeConverter
    {
        public JsonTimeConverter()
        {
            Culture = new CultureInfo("sv-SE"); //Force ISO 8601
            DateTimeFormat = "t";
        }
    }
}