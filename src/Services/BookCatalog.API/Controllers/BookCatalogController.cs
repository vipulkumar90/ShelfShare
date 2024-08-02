using BookCatalog.API.Models;
using BookCatalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookCatalog.API.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BookCatalogController : ControllerBase
	{
		private readonly IBookRepository _bookRepository;
		private readonly ILogger<BookCatalogController> _logger;
		private readonly string _logContext = $"[{typeof(BookCatalogController).Name}]";
		public BookCatalogController(IBookRepository bookRepository, ILogger<BookCatalogController> logger)
		{
			_bookRepository = bookRepository;
			_logger = logger;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetAsync()
		{
			try
			{
				_logger.LogInformation($"{_logContext} Getting all books");
				var books = await _bookRepository.ReadAsync();
				_logger.LogInformation($"{_logContext} Retrieved all books");
				return Ok(books);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetAsync([FromRoute] Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Getting book with id:{id}");
				Book? book = await _bookRepository.ReadAsync(id);
				if (book == null)
				{
					_logger.LogInformation($"{_logContext} Book with id:{id} is not found");
					return NotFound();
				}
				_logger.LogInformation($"{_logContext} Book with id:{id} fetched successfully");
				return Ok(book);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] BookDto bookDto)
		{

			try
			{
				_logger.LogInformation($"{_logContext} Creating a book entry");
				var bookId = await _bookRepository.CreateAsync(bookDto);
				_logger.LogInformation($"{_logContext} Book with id:{bookId} has been created.");
				return Created();
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpPut("{id}")]
		public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] BookDto bookDto)
		{
			try
			{
				_logger.LogInformation($"{_logger} Updating a book with id:{id}");
				var updatedBook = await _bookRepository.UpdateAsync(id, bookDto);
				if (updatedBook == null)
				{
					_logger.LogInformation($"{_logContext} Book with id:{id} doesn't exist");
					return BadRequest();
				}
				_logger.LogInformation($"{_logContext} Updated book with id:{id} successfully");
				return Ok(updatedBook);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logger} Deleting a book with id:{id}");
				var isDeleted = await _bookRepository.DeleteAsync(id);
				if (isDeleted == false)
				{
					_logger.LogInformation($"{_logContext} Book with id:{id} doesn't exist");
					return BadRequest();
				}
				_logger.LogInformation($"{_logContext} Deleted book with id:{id} successfully");
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
	}
}
