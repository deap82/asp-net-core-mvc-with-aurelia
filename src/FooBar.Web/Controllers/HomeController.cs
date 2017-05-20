using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FooBar.Web.Models;

namespace FooBar.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Start()
		{
			return View();
		}

		public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

		public IActionResult Person()
		{
			PersonModel model = new PersonModel
			{
				FirstName = "John",
				LastName = "Doe",
				Occupation = "Developer",
				Age = 35
			};
			return View(model);
		}

		public IActionResult Error()
        {
            return View();
        }
    }
}
