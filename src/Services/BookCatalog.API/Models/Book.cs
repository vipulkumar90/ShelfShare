using System.ComponentModel.DataAnnotations;

namespace BookCatalog.API.Models
{
	public class Book
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public string Genre { get; set; } = string.Empty;
		public int Year { get; set; }
		public bool IsAvailable { get; set; }
	}

}
