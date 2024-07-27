using BookLoanManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLoanManagement.API.DataContext
{
	public class BookLoanManagementContext : DbContext
	{
        public BookLoanManagementContext(DbContextOptions<BookLoanManagementContext> options)
            :base(options) { }

        public DbSet<Loan> Loans { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Loan>().HasKey(r => r.Id);
			modelBuilder.Entity<Loan>().HasData(
				new Loan
				{
					Id = Guid.Parse("d5a8f7d3-65b8-4c4b-a6d3-67d1a5e6e0b7"),
					UserId = Guid.Parse("9d2e0c9b-44a3-4e1c-a5d9-f8f5f730dc4b"),
					BookId = Guid.Parse("e7868a4a-b02f-417d-a2c2-ad4e62ed330b"),
					BorrowedAt = new DateTime(2024, 6, 15, 10, 30, 0),
					DueDate = new DateTime(2024, 7, 15, 10, 30, 0),
					ReturnedAt = new DateTime(2024, 7, 14, 15, 0, 0)
				},
				new Loan
				{
					Id = Guid.Parse("a2e4d8f0-3c2d-4a7e-9b6c-1a8b7a5d6e4f"),
					UserId = Guid.Parse("a3f1e8d9-44b2-4d9a-9a7c-c8e0f9a2d1b4"),
					BookId = Guid.Parse("1008ef60-a3ee-404f-b099-1c67c09c9d03"),
					BorrowedAt = new DateTime(2024, 6, 20, 9, 0, 0),
					DueDate = new DateTime(2024, 7, 20, 9, 0, 0),
					ReturnedAt = new DateTime(2024, 7, 19, 12, 0, 0)
				},
				new Loan
				{
					Id = Guid.Parse("b6c8f3d9-1e7b-4a1d-9b8e-5f6a7c8d9e2b"),
					UserId = Guid.Parse("c8b0d3a2-7d6e-4f9a-8e1b-3d7f8c6a2e9b"),
					BookId = Guid.Parse("1beb2e27-8b39-4ddf-9c62-ac80d950ea8a"),
					BorrowedAt = new DateTime(2024, 6, 25, 14, 0, 0),
					DueDate = new DateTime(2024, 7, 25, 14, 0, 0),
					ReturnedAt = new DateTime(2024, 7, 26, 11, 0, 0)
				},
				new Loan
				{
					Id = Guid.Parse("e7d9f4c0-9b6e-4c2a-8d1a-3e5b6c8d9f0a"),
					UserId = Guid.Parse("d1e8a9b0-4c5f-6d7e-8b9c-2f3d6a7b8e9f"),
					BookId = Guid.Parse("e555abcd-5fea-449d-96b7-9065fdbc8988"),
					BorrowedAt = new DateTime(2024, 6, 30, 8, 0, 0),
					DueDate = new DateTime(2024, 7, 30, 8, 0, 0),
					ReturnedAt = null
				},
				new Loan
				{
					Id = Guid.Parse("c9d2e4f1-6a5b-4c9e-8f3a-2d1e7c8a9f0b"),
					UserId = Guid.Parse("e3f1c9d0-7a2b-4d6e-9b8a-3c4d5e6f7a8b"),
					BookId = Guid.Parse("c2eae320-a002-450f-90a8-02530c219b6f"),
					BorrowedAt = new DateTime(2024, 7, 1, 13, 0, 0),
					DueDate = new DateTime(2024, 8, 1, 13, 0, 0),
					ReturnedAt = new DateTime(2024, 7, 31, 16, 0, 0)
				}
			);
		}
	}
}
