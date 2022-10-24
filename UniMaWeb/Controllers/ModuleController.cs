using Microsoft.AspNetCore.Mvc;
using UniMaWeb.Data;
using UniMaWeb.Models;

namespace UniMaWeb.Controllers;

[ApiController]
[Produces("application/json", "application/xml")]
[Route("api/[controller]")]
public class ModuleController : Controller
{
	private readonly ModuleContext _context;

	public ModuleController(ModuleContext context)
	{
		_context = context;
	}
	
	[HttpGet(Name = "GetModules")]
	public IEnumerable<Module> GetModules()
	{
		return _context.Modules.ToArray();
	}
}