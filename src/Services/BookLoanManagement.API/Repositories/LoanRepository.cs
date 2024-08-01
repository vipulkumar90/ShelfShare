using BookLoanManagement.API.DataContext;
using BookLoanManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLoanManagement.API.Repositories
{
	public class LoanRepository : ILoanRepository
	{
		private readonly BookLoanManagementContext _context;
		private readonly string _logContext = $"[{typeof(LoanRepository).Name}]";
		private readonly ILogger<LoanRepository> _logger;
		public LoanRepository(BookLoanManagementContext context, ILogger<LoanRepository> logger)
        {
            _context = context;
			_logger = logger;
        }
        public async Task<Guid> CreateAsync(LoanDto loanDto)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Inserting a book loan into db");
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
				_logger.LogInformation($"{_logContext} Inserted a book loan with id:{loan.Id} successfully");
				return loan.Id;
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
				_logger.LogInformation($"{_logContext} Removing a book loan with id:{id}");
				var loanToBeDeleted = await _context.Loans.FindAsync(id);
				if (loanToBeDeleted == null)
				{
					_logger.LogInformation($"{_logContext} Book loan with id:{id} doesn't exist");
					return false;
				}
				_context.Remove(loanToBeDeleted);
				await _context.SaveChangesAsync();
				_logger.LogInformation($"{_logContext} Removed the book loan with id:{id}");
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}

		public async Task<IEnumerable<Loan>> ReadAsync()
		{
			try
			{
				_logger.LogInformation($"{_logContext} Fetching all the book loans");
				var loans = await _context.Loans.ToListAsync();
				_logger.LogInformation($"{_logContext} Feteched all book loans");
				return loans;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}

		public async Task<Loan?> ReadAsync(Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Fetching details of a book loan with id:{id}");
				var loan = await _context.Loans.FindAsync(id);
				_logger.LogInformation($"{_logContext} Fetched details of a book loan with id:{id}");
				return loan;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}

		public async Task<Loan?> UpdateAsync(Guid id, LoanDto loanDto)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Modifying details of a book loan with id:{id}");
				var loanToBeUpdated = await _context.Loans.FindAsync(id);
				if (loanToBeUpdated == null)
				{
					_logger.LogInformation($"{_logContext} Book loan with id:{id} doesn't exist");
					return null;
				}
				loanToBeUpdated.BookId = loanDto.BookId;
				loanToBeUpdated.UserId = loanDto.UserId;
				loanToBeUpdated.BorrowedAt = loanDto.BorrowedAt;
				loanToBeUpdated.DueDate = loanDto.DueDate;
				loanToBeUpdated.ReturnedAt = loanDto.ReturnedAt;
				_context.Update(loanToBeUpdated);
				await _context.SaveChangesAsync();
				_logger.LogInformation($"{_logContext} Modified details of the book loan with id:{id}");
				return loanToBeUpdated;
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				throw;
			}
		}
	}
}
