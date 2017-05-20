using Newtonsoft.Json;

namespace FooBar.Web.Core.Json
{
    public static class JsonObjectExtensions
    {
        public static string ToJsonCamelCase(this object obj)
        {
            JsonSerializerSettings settings = JsonHelpers.CreateJsonSerializerSettings();
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }
    }
}