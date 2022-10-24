using Microsoft.EntityFrameworkCore;

namespace UniMaWeb.Models;

// https://learn.microsoft.com/de-de/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
// https://learn.microsoft.com/de-de/ef/core/modeling/
public class Module
{
	public string Id { get; set; }
	public string Url { get; set; }
	public string Title { get; set; }
	public string Directory { get; set; }
	public string? Vessel { get; set; }
	public string Color { get; set; }
	public string SectionTitles { get; set; }
	public string Structure { get; set; }
	public int InternalId { get; set; }

	public Module()
	{
	}
	
	public Module(string id, string url, string title, string directory, string? vessel, string color, string sectionTitles, string structure, int internalId)
	{
		Id = id;
		Url = url;
		Title = title;
		Directory = directory;
		Vessel = vessel;
		Color = color;
		SectionTitles = sectionTitles;
		Structure = structure;
		InternalId = internalId;
	}
}