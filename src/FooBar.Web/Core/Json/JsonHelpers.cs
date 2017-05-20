using Newtonsoft.Json;

namespace FooBar.Web.Core.Json
{
    public static class JsonHelpers
    {
        public static JsonSerializerSettings CreateJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new FooBarContractResolver() };
            settings.Converters.Add(new JsonDateConverter());
            return settings;
        }

    }
}
