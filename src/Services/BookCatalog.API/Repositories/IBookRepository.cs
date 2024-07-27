using BookCatalog.API.Models;

namespace BookCatalog.API.Repositories
{
	public interface IBookRepository
	{
		Task<IEnumerable<Book>> ReadAsync();
		Task<Book?> ReadAsync(Guid id);
		Task CreateAsync(BookDto bookDto);
		Task<Book?> UpdateAsync(Guid id, BookDto bookDto);
		Task<bool> DeleteAsync(Guid id);
	}
}
