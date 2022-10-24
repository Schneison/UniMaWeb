using Microsoft.AspNetCore.Mvc;

namespace UniMaWeb.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
public class HomeController : Controller
{
	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}
}