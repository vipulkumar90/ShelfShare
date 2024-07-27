using BookCatalog.API.DataContext;
using BookCatalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BookCatalogController : ControllerBase
	{
		private readonly BookCatalogContext _bookCatalogContext;
		public BookCatalogController(BookCatalogContext bookCatalogContext)
		{
			_bookCatalogContext = bookCatalogContext;
		}
		[HttpGet]
		public ActionResult<IEnumerable<Book>> Get()
		{
			return Ok(_bookCatalogContext.Books.ToList());
		}
		[HttpGet("{id}")]
		public ActionResult<Book> Get([FromRoute] Guid id)
		{
			var book = _bookCatalogContext.Books.FirstOrDefault(book => book.Id == id);
			if (book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}
		[HttpPost]
		public ActionResult Post([FromBody] BookDto bookDto)
		{
			var book = new Book
			{
				Title = bookDto.Title,
				Author = bookDto.Author,
				Genre = bookDto.Genre,
				Year = bookDto.Year,
				IsAvailable = bookDto.IsAvailable,
			};
			_bookCatalogContext.Books.Add(book);
			_bookCatalogContext.SaveChanges();
			return Created();
		}
		[HttpPut("{id}")]
		public ActionResult Put([FromRoute] Guid id, [FromBody] BookDto bookDto)
		{
			var bookToBeUpdated = _bookCatalogContext.Books.FirstOrDefault(book => book.Id == id);
			if (bookToBeUpdated == null)
			{
				return BadRequest();
			}
			bookToBeUpdated.Title = bookDto.Title;
			bookToBeUpdated.Author = bookDto.Author;
			bookToBeUpdated.Genre = bookDto.Genre;
			bookToBeUpdated.Year = bookDto.Year;
			bookToBeUpdated.IsAvailable = bookDto.IsAvailable;
			_bookCatalogContext.Update(bookToBeUpdated);
			_bookCatalogContext.SaveChanges();
			return Ok(bookToBeUpdated);
		}
		[HttpDelete("{id}")]
		public ActionResult Delete([FromRoute] Guid id)
		{
			var bookToBeDeleted = _bookCatalogContext.Books.FirstOrDefault(book => book.Id == id);
			if (bookToBeDeleted == null)
			{
				return BadRequest();
			}
			_bookCatalogContext.Remove(bookToBeDeleted); 
			_bookCatalogContext.SaveChanges();
			return NoContent();
		}
	}
}
