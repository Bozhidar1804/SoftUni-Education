using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult TextSplitter(TextViewModel model)
		{
			return View(model);
		}

		[HttpPost]
		public IActionResult Split(TextViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.RedirectToAction("TextSplitter", model);
			}

			string[] splitTextArray = model
				.Text
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			model.SplitText = string.Join(Environment.NewLine, splitTextArray);
			return RedirectToAction("TextSplitter", model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
