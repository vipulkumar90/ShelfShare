﻿namespace BookLoanManagement.API.Models
{
	public class Loan
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid BookId { get; set; }
		public DateTime BorrowedAt { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? ReturnedAt { get; set; }
	}
}
