using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FooBar.Web.TagHelpers
{
	[HtmlTargetElement(Attributes = VkAuBindPrefix + "*")]
	public class AureliaBindTagHelper : TagHelper
	{
		private const string VkAuBindPrefix = "th-au-bind-";
		private const string VkAuValueConvertersPrefix = "th-au-value-converters-";
		private const string VkAuBindingBehaviorsPrefix = "th-au-binding-behaviors-";

		private IDictionary<string, ModelExpression> _allModels;
		/// <summary>
		/// If attribute is foo and MVC Model member is Bar; th-au-bind-foo="Bar"
		/// To change binding type from default .bind; th-au-bind-foo.one-time="Bar" (other possibles are .one-way and .two-way) 
		/// </summary>
		[HtmlAttributeName("th-au-all-models", DictionaryAttributePrefix = VkAuBindPrefix)]
		public IDictionary<string, ModelExpression> AllModels {
			get {
				return _allModels ??
					   (_allModels = new Dictionary<string, ModelExpression>(StringComparer.OrdinalIgnoreCase));
			}
			set {
				_allModels = value;
			}
		}

		private IDictionary<string, string> _allValueConverters;
		/// <summary>
		/// Aurelia Value Converters to use for each binding. If multiple separate with |.
		/// To set for attribute foo: th-au-value-converters-foo="conv1"
		/// </summary>
		[HtmlAttributeName("th-au-all-value-converters", DictionaryAttributePrefix = VkAuValueConvertersPrefix)]
		public IDictionary<string, string> AllValueConverters {
			get {
				return _allValueConverters ??
					   (_allValueConverters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
			}
			set {
				_allValueConverters = value;
			}
		}

		private IDictionary<string, string> _allBindingBehaviors;
		/// <summary>
		/// Aurelia Binding Behaviours to use for each binding. If multiple separate with &.
		/// To set for attribute foo: th-au-binding-behaviors-foo="beh1"
		/// </summary>
		[HtmlAttributeName("th-au-all-binding-behaviors", DictionaryAttributePrefix = VkAuBindingBehaviorsPrefix)]
		public IDictionary<string, string> AllBindingBehaviors {
			get {
				return _allBindingBehaviors ??
					   (_allBindingBehaviors = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
			}
			set {
				_allBindingBehaviors = value;
			}
		}

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			foreach (KeyValuePair<string, ModelExpression> item in AllModels)
			{
				string attributeName = item.Key;
				string bindType = "bind";
				if (attributeName.Contains("."))
				{
					var parts = attributeName.Split('.');
					attributeName = parts[0];
					bindType = parts[1];
				}

				string expression = BuildExpression(item.Value);

				string valueConverters = "";
				if (AllValueConverters.ContainsKey(attributeName))
				{
					valueConverters = AllValueConverters[attributeName];
				}

				string bindingBehaviors = "";
				if (AllBindingBehaviors.ContainsKey(attributeName))
				{
					bindingBehaviors = AllBindingBehaviors[attributeName];
				}

				expression = AddConvertersAndBehaviors(expression, valueConverters, bindingBehaviors);

				output.Attributes.SetAttribute(attributeName + "." + bindType, expression);
			}
		}

		public static string BuildExpression(ModelExpression model)
		{
			string name = model.Name;

			if (String.IsNullOrEmpty(name))
			{
				throw new InvalidOperationException("AureliaGenericBindTagHelper could not resolve name from the given ModelExpression.");
			}

			string result = string.Empty;
			string[] parts = name.Split('.');
			for (int i = 0; i < parts.Length; i++)
			{
				if (i > 0)
				{
					result += ".";
				}
				string part = parts[i][0].ToString().ToLowerInvariant() + parts[i].Substring(1); //Make camelCase;
				result += part;
			}
			result = "data." + result; //"data" is by convention the name of any MVC Model added as data to a client side model.
			return result;
		}

		public static string AddConvertersAndBehaviors(string bindExpression, string valueConverters, string bindingBehaviors)
		{
			string result = bindExpression;

			if (!String.IsNullOrWhiteSpace(valueConverters))
			{
				result += " | " + valueConverters;
			}

			if (!String.IsNullOrWhiteSpace(bindingBehaviors))
			{
				result += " & " + bindingBehaviors;
			}

			return result;
		}
	}
}