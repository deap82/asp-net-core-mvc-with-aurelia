using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace FooBar.Web.HtmlHelpers
{
    public static class CacheBustHtmlHelperExtension
    {
        public static string CacheBust(this IHtmlHelper helper, IHostingEnvironment hostingEnvironment, string path, bool removeExtension = false)
        {
            var cacheBustPath = Path.Combine(hostingEnvironment.WebRootPath, "dist/cachebust.json");
            if (cacheBustPath == null || !File.Exists(cacheBustPath)) return path;
            var jsons = File.ReadAllText(cacheBustPath);
            dynamic data = JObject.Parse(jsons);
            path = ((string)(data[path] ?? path));
            var dotIndex = path.LastIndexOf('.');
            return removeExtension && dotIndex > -1 ? path.Substring(0, dotIndex) : path;
        }
    }
}
