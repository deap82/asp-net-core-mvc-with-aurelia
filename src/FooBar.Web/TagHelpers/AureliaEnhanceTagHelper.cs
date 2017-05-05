using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace FooBar.Web.TagHelpers
{
	[HtmlTargetElement(Attributes = HtmlIdAttributeName + ", " + AuEnhanceAttributeName)]
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

			string elementId = Convert.ToString(output.Attributes["id"].Value);

			output.PostElement.AppendHtml($@"
                <script>
                    SystemJS.import('app/core/aurelia-enhancer').then(enhancer => {{
						enhancer.enhance(document.getElementById('{elementId}'));
                    }});
                </script>");
		}
	}
}
