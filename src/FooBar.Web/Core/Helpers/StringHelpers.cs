using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBar.Web.Core.Helpers
{
	public static class StringHelpers
	{
		private static readonly Random _random = new Random();
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[_random.Next(s.Length)]).ToArray());
		}
	}
}
