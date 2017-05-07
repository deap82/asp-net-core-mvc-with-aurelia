using FooBar.Web.Core.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace FooBar.Web.TagHelpers
{
	[HtmlTargetElement(Attributes = AuEnhanceAttributeName)]
	[HtmlTargetElement(Attributes = AuModuleAttributeName)]
	public class AureliaEnhanceTagHelper : TagHelper
	{
		private const string HtmlIdAttributeName = "id";

		private const string AuEnhanceAttributeName = "th-aurelia-enhance";
		[HtmlAttributeName(AuEnhanceAttributeName)]
		public bool Enhance { get; set; }

		private const string AuModuleAttributeName = "th-aurelia-enhance-module";
		[HtmlAttributeName(AuModuleAttributeName)]
		public string Module { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			Enhance = !String.IsNullOrEmpty(Module);

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

			if(!String.IsNullOrEmpty(Module))
			{
				output.PostElement.AppendHtml($@"
                <script>
                    SystemJS.import('app/core/aurelia-enhancer').then(enhancer => {{
						SystemJS.import('{Module}').then(module => {{
							var clientModel = module.create();
							enhancer.enhance(clientModel, document.getElementById('{elementId}'));
						}});
                    }});
                </script>");
			}
			else
			{
				output.PostElement.AppendHtml($@"
                <script>
                    SystemJS.import('app/core/aurelia-enhancer').then(enhancer => {{
						enhancer.enhance({{}}, document.getElementById('{elementId}'));
                    }});
                </script>");
			}
		}
	}
}
