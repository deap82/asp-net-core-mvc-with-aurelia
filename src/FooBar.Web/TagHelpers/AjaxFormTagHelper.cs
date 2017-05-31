using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBar.Web.TagHelpers
{
	[HtmlTargetElement("form", Attributes = "[data-ajax=true]")]
	public class AjaxFormTagHelper : TagHelper
    {
		public const string WrapperClass = "razor-load-area";
		
		private const string HtmlAjaxMethodAttributeName = "data-ajax-method";
		private const string HtmlAjaxUpdateAttributeName = "data-ajax-update";
		private const string HtmlAjaxModeAttributeName = "data-ajax-mode";
		
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (!output.Attributes.ContainsName(HtmlAjaxMethodAttributeName))
			{
				output.Attributes.Add(HtmlAjaxMethodAttributeName, "POST");
			}
			
			if (!output.Attributes.ContainsName(HtmlAjaxUpdateAttributeName))
			{
				output.Attributes.Add(HtmlAjaxUpdateAttributeName, "." + WrapperClass);
			}

			if (!output.Attributes.ContainsName(HtmlAjaxModeAttributeName))
			{
				output.Attributes.Add(HtmlAjaxModeAttributeName, "replace-with");
			}
		}
	}
}
