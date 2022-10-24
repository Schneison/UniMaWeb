using Microsoft.AspNetCore.Mvc;

namespace UniMaWeb.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("pages/[controller]")]
public class HelloWorldController : Controller
{
	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}
}