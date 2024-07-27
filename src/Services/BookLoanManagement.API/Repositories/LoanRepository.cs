using BookLoanManagement.API.DataContext;
using BookLoanManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLoanManagement.API.Repositories
{
	public class LoanRepository : ILoanRepository
	{
		private readonly BookLoanManagementContext _context;
        public LoanRepository(BookLoanManagementContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(LoanDto loanDto)
		{
			try
			{
				var loan = new Loan
				{
					BookId = loanDto.BookId,
					UserId = loanDto.UserId,
					BorrowedAt = loanDto.BorrowedAt,
					DueDate = loanDto.DueDate,
					ReturnedAt = loanDto.ReturnedAt
				};
				await _context.AddAsync(loan);
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
				var loanToBeDeleted = await _context.Loans.FindAsync(id);
				if (loanToBeDeleted == null)
				{
					return false;
				}
				_context.Remove(loanToBeDeleted);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<Loan>> ReadAsync()
		{
			try
			{
				return await _context.Loans.ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<Loan?> ReadAsync(Guid id)
		{
			try
			{
				return await _context.Loans.FindAsync(id);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<Loan?> UpdateAsync(Guid id, LoanDto loanDto)
		{
			try
			{
				var loanToBeUpdated = await _context.Loans.FindAsync(id);
				if (loanToBeUpdated == null)
				{
					return null;
				}
				loanToBeUpdated.BookId = loanDto.BookId;
				loanToBeUpdated.UserId = loanDto.UserId;
				loanToBeUpdated.BorrowedAt = loanDto.BorrowedAt;
				loanToBeUpdated.DueDate = loanDto.DueDate;
				loanToBeUpdated.ReturnedAt = loanDto.ReturnedAt;
				_context.Update(loanToBeUpdated);
				await _context.SaveChangesAsync();
				return loanToBeUpdated;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
