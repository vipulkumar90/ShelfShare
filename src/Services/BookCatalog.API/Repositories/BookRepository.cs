using BookCatalog.API.Controllers;
using BookCatalog.API.DataContext;
using BookCatalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly BookCatalogContext _context;
		private readonly string _logContext = $"[{typeof(BookRepository).Name}]";
		private readonly ILogger<BookRepository> _logger;
		public BookRepository(BookCatalogContext context, ILogger<BookRepository> logger)
        {
            _context = context;
			_logger = logger;
        }
        public async Task<Guid> CreateAsync(BookDto bookDto)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Inserting a book into db");
				var book = new Book
				{
					Title = bookDto.Title,
					Author = bookDto.Author,
					Genre = bookDto.Genre,
					Year = bookDto.Year,
					IsAvailable = bookDto.IsAvailable,
				};
				await _context.Books.AddAsync(book);
				await _context.SaveChangesAsync();
				_logger.LogInformation($"{_logContext} Inserted a book with id:{book.Id} successfully");
				return book.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}

		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Removing a book with id:{id}");
				var bookToBeDeleted = await _context.Books.FindAsync(id);
				if (bookToBeDeleted == null)
				{
					_logger.LogInformation($"{_logContext} Book with id:{id} doesn't exist");
					return false;
				}
				_context.Remove(bookToBeDeleted);
				await _context.SaveChangesAsync();
				_logger.LogInformation($"{_logContext} Removed the book with id:{id}");
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}

		public async Task<IEnumerable<Book>> ReadAsync()
		{
			try
			{
				_logger.LogInformation($"{_logContext} Fetching all the books");
				var books = await _context.Books.ToListAsync();
				_logger.LogInformation($"{_logContext} Feteched all books");
				return books;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}

		public async Task<Book?> ReadAsync(Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Fetching details of a book with id:{id}");
				var book = await _context.Books.FindAsync(id);
				_logger.LogInformation($"{_logContext} Fetched details of a book with id:{id}");
				return book;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}

		public async Task<Book?> UpdateAsync(Guid id, BookDto bookDto)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Modifying details of a book with id:{id}");
				var bookToBeUpdated = await _context.Books.FindAsync(id);
				if (bookToBeUpdated == null)
				{
					_logger.LogInformation($"{_logContext} Book with id:{id} doesn't exist");
					return null;
				}
				bookToBeUpdated.Title = bookDto.Title;
				bookToBeUpdated.Author = bookDto.Author;
				bookToBeUpdated.Genre = bookDto.Genre;
				bookToBeUpdated.Year = bookDto.Year;
				bookToBeUpdated.IsAvailable = bookDto.IsAvailable;
				_context.Update(bookToBeUpdated);
				await _context.SaveChangesAsync();
				_logger.LogInformation($"{_logContext} Modified details of the book with id:{id}");
				return bookToBeUpdated;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}
	}
}
