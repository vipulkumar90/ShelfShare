using BookLoanManagement.API.Models;

namespace BookLoanManagement.API.Repositories
{
	public interface ILoanRepository
	{
		Task<IEnumerable<Loan>> ReadAsync();
		Task<Loan?> ReadAsync(Guid id);
		Task CreateAsync(LoanDto loanDto);
		Task<Loan?> UpdateAsync(Guid id, LoanDto loanDto);
		Task<bool> DeleteAsync(Guid id);
	}
}
