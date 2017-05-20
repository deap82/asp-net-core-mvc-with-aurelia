using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Web.Models
{
    public class PersonModel
    {
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[JsonIgnore]
		[Display(Name = "Occupation")]
		public string Occupation { get; set; }

		[Display(Name = "Age [this year]")]
		public int Age { get; set; }
	}
}