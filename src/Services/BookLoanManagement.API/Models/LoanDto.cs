namespace BookLoanManagement.API.Models
{
	public class LoanDto
	{
		public Guid UserId { get; set; }
		public Guid BookId { get; set; }
		public DateTime BorrowedAt { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? ReturnedAt { get; set; }
	}
}
