using BookCatalog.API.DataContext;
using BookCatalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly BookCatalogContext _context;
        public BookRepository(BookCatalogContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(BookDto bookDto)
		{
			try
			{
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
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				var bookToBeDeleted = await _context.Books.FindAsync(id);
				if (bookToBeDeleted == null)
				{
					return false;
				}
				_context.Remove(bookToBeDeleted);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<Book>> ReadAsync()
		{
			try
			{
				var books = await _context.Books.ToListAsync();
				return books;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<Book?> ReadAsync(Guid id)
		{
			try
			{
				return await _context.Books.FindAsync(id);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<Book?> UpdateAsync(Guid id, BookDto bookDto)
		{
			try
			{
				var bookToBeUpdated = await _context.Books.FindAsync(id);
				if (bookToBeUpdated == null)
				{
					return null;
				}
				bookToBeUpdated.Title = bookDto.Title;
				bookToBeUpdated.Author = bookDto.Author;
				bookToBeUpdated.Genre = bookDto.Genre;
				bookToBeUpdated.Year = bookDto.Year;
				bookToBeUpdated.IsAvailable = bookDto.IsAvailable;
				_context.Update(bookToBeUpdated);
				await _context.SaveChangesAsync();
				return bookToBeUpdated;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
