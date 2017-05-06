using FooBar.Web.Core.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace FooBar.Web.TagHelpers
{
	[HtmlTargetElement(Attributes = AuEnhanceAttributeName)]
	public class AureliaEnhanceTagHelper : TagHelper
	{
		private const string HtmlIdAttributeName = "id";
		private const string AuEnhanceAttributeName = "th-aurelia-enhance";
		
		[HtmlAttributeName(AuEnhanceAttributeName)]
		public bool Enhance { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (!Enhance)
			{
				return;
			}

			string elementId;
			if (!output.Attributes.ContainsName(HtmlIdAttributeName))
			{
				elementId = StringHelpers.RandomString(8);
				output.Attributes.SetAttribute(HtmlIdAttributeName, elementId);
			}
			else
			{
				elementId = Convert.ToString(output.Attributes[HtmlIdAttributeName].Value);
			}
			
			output.PostElement.AppendHtml($@"
                <script>
                    SystemJS.import('app/core/aurelia-enhancer').then(enhancer => {{
						enhancer.enhance(document.getElementById('{elementId}'));
                    }});
                </script>");
		}
	}
}
