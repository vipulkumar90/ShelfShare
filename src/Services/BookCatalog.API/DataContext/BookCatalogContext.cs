using BookCatalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API.DataContext
{
	public class BookCatalogContext : DbContext
	{
        public BookCatalogContext(DbContextOptions<BookCatalogContext> options) 
            : base(options) { }

        public DbSet<Book> Books { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().HasKey(r => r.Id);
			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					Id = new Guid("e7868a4a-b02f-417d-a2c2-ad4e62ed330b"),
					Title = "To Kill a Mockingbird",
					Author = "Harper Lee",
					Genre = "Fiction",
					Year = 1960,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("1008ef60-a3ee-404f-b099-1c67c09c9d03"),
					Title = "1984",
					Author = "George Orwell",
					Genre = "Dystopian",
					Year = 1949,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("1beb2e27-8b39-4ddf-9c62-ac80d950ea8a"),
					Title = "Moby-Dick",
					Author = "Herman Melville",
					Genre = "Adventure",
					Year = 1851,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("e555abcd-5fea-449d-96b7-9065fdbc8988"),
					Title = "Pride and Prejudice",
					Author = "Jane Austen",
					Genre = "Romance",
					Year = 1813,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("c2eae320-a002-450f-90a8-02530c219b6f"),
					Title = "The Great Gatsby",
					Author = "F. Scott Fitzgerald",
					Genre = "Classic",
					Year = 1925,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("b656d13d-b535-43e2-8033-1fc3a2e8b407"),
					Title = "Catch-22",
					Author = "Joseph Heller",
					Genre = "Satire",
					Year = 1961,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("3b886122-9694-4344-b9c0-76a698b5ff6d"),
					Title = "Brave New World",
					Author = "Aldous Huxley",
					Genre = "Science Fiction",
					Year = 1932,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("592c6862-b1dd-49c3-abb7-0533975e6fe3"),
					Title = "The Catcher in the Rye",
					Author = "J.D. Salinger",
					Genre = "Literary Fiction",
					Year = 1951,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("cc92563e-1bed-42cb-881e-ced59069cef1"),
					Title = "The Hobbit",
					Author = "J.R.R. Tolkien",
					Genre = "Fantasy",
					Year = 1937,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("fde534ad-7c61-4620-b5a1-ff8237a0decf"),
					Title = "Animal Farm",
					Author = "George Orwell",
					Genre = "Political Satire",
					Year = 1945,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("51c8ab13-436c-401c-a45a-bd24885a50fb"),
					Title = "Jane Eyre",
					Author = "Charlotte Brontë",
					Genre = "Gothic Fiction",
					Year = 1847,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("b968c0a0-d84a-4ca6-b782-406350eb55f8"),
					Title = "The Picture of Dorian Gray",
					Author = "Oscar Wilde",
					Genre = "Philosophical Fiction",
					Year = 1890,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("7971d814-17ea-439d-8d44-c0501c0dfd35"),
					Title = "Wuthering Heights",
					Author = "Emily Brontë",
					Genre = "Classic",
					Year = 1847,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("d752ddd9-b00d-4644-a456-4ef40fb407dc"),
					Title = "Little Women",
					Author = "Louisa May Alcott",
					Genre = "Coming-of-Age",
					Year = 1868,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("d53cca64-c1ea-466c-a5f3-411cf3745624"),
					Title = "The Chronicles of Narnia",
					Author = "C.S. Lewis",
					Genre = "Fantasy",
					Year = 1950,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("fa7c3f20-41db-48e4-b9fe-4c5625519686"),
					Title = "The Da Vinci Code",
					Author = "Dan Brown",
					Genre = "Thriller",
					Year = 2003,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("57c98222-c2c6-4532-a4af-87321d704cfb"),
					Title = "Dune",
					Author = "Frank Herbert",
					Genre = "Science Fiction",
					Year = 1965,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("5e22438d-72de-4424-990e-29db2edae0fb"),
					Title = "The Road",
					Author = "Cormac McCarthy",
					Genre = "Post-Apocalyptic",
					Year = 2006,
					IsAvailable = true
				},
				new Book
				{
					Id = new Guid("de506183-2497-465d-a5fe-2e553d6dea93"),
					Title = "Gone with the Wind",
					Author = "Margaret Mitchell",
					Genre = "Historical Fiction",
					Year = 1936,
					IsAvailable = false
				},
				new Book
				{
					Id = new Guid("58e43cef-d693-4f4f-8f22-6f57d4748863"),
					Title = "The Great Alone",
					Author = "Kristin Hannah",
					Genre = "Historical Fiction",
					Year = 2018,
					IsAvailable = true
				}
			);
		}
	}
}
