using BookCatalog.API.Models;
using BookCatalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BookCatalogController : ControllerBase
	{
		private readonly IBookRepository _bookRepository;
		public BookCatalogController(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetAsync()
		{
			try
			{
				return Ok(await _bookRepository.ReadAsync());
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetAsync([FromRoute] Guid id)
		{
			try
			{
				Book? book = await _bookRepository.ReadAsync(id);
				if (book == null)
				{
					return NotFound();
				}
				return Ok(book);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] BookDto bookDto)
		{

			try
			{
				await _bookRepository.CreateAsync(bookDto);
				return Created();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpPut("{id}")]
		public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] BookDto bookDto)
		{
			try
			{
				var updatedBook = await _bookRepository.UpdateAsync(id, bookDto);
				if (updatedBook == null)
				{
					return BadRequest();
				}
				return Ok(updatedBook);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var isDeleted = await _bookRepository.DeleteAsync(id);
				if (isDeleted == false)
				{
					return BadRequest();
				}
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
	}
}
