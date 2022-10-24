using Microsoft.EntityFrameworkCore;
using UniMaWeb.Models;

namespace UniMaWeb.Data;

public class ModuleContext : DbContext
{
	public ModuleContext(DbContextOptions<ModuleContext> options) : base(options)
	{
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Module>()
			.Property(m => m.Structure)
			.HasDefaultValue("compact");
		modelBuilder.Entity<Module>().ToTable("modules");
	}

	public DbSet<Module> Modules { get; set; }
}