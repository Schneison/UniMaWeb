using Microsoft.EntityFrameworkCore;
using UniMaWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();
builder.Services.AddMvcCore().AddRazorViewEngine();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
	c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
	c.IgnoreObsoleteActions();
	c.IgnoreObsoleteProperties();
	c.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddDbContext<ModuleContext>(
	options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
	);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
// app.UseDefaultFiles();
// app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
// Routes the endpoint
app.UseEndpoints(endpoints =>
{
	void RespondWithRedirect(HttpResponse response, string location)
	{
		response.StatusCode = 301;
		response.Headers["Location"] = location;
		response.Headers["Cache-Control"] = "no-store";
	}
	
	//endpoints.MapGet("/", context => Task.Run(() => RespondWithRedirect(context.Response, "home")));
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}",
		defaults: new {controller="Home", action="Index"});
	 endpoints.MapGet("/", 
		 context => Task.Run(()=>RespondWithRedirect(context.Response, "home"))
		 );
	// endpoints.MapGet("/*/home", async context => RespondWithRedirect(context.Response, "home"));
});

// app.MapControllerRoute(
// 	name: "Home",
// 	pattern: "",
// 	defaults: new 
// 	{ 
// 		controller = "Home", 
// 		action = "Index",
// 	}
// );
//app.MapControllers();
// app.MapControllerRoute(
// 	name: "Default",
// 	pattern: "{controller=Home}/{action=Index}",
// 	defaults: new
// 	{
// 		controller = "Home",
// 		action = "Index",
// 	}
// );

app.Run();