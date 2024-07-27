using System.ComponentModel.DataAnnotations;

namespace BookCatalog.API.Models
{
	public class Book
	{
		public Guid Id { get; set; }
		[Required]
		public string Title { get; set; } = string.Empty;
		[Required]
		public string Author { get; set; } = string.Empty;
		[Required]
		public string Genre { get; set; } = string.Empty;
		[Required]
		public int Year { get; set; }
		[Required]
		public bool IsAvailable { get; set; }
	}

}
