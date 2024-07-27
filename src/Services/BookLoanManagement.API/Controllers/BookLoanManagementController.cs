using BookLoanManagement.API.Models;
using BookLoanManagement.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookLoanManagement.API.Controllers
{
	[Route("api/loan")]
	[ApiController]
	public class BookLoanManagementController : ControllerBase
	{
		private readonly ILoanRepository _loanRepository;
        public BookLoanManagementController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        //Borrow a book (create a book loan)
        [HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] LoanDto loanDto)
		{
			try
			{
				await _loanRepository.CreateAsync(loanDto);
				return Created();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Retrieve the list of loans
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Loan>>> GetAsync() 
		{
			try
			{
				var loans = await _loanRepository.ReadAsync();
				return Ok(loans);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Retrieve details of a specific loan
		[HttpGet("{id}")]
		public async Task<ActionResult<Loan>> GetAsync(Guid id)
		{
			try
			{
				var loan = await _loanRepository.ReadAsync(id);
				if (loan == null)
				{
					return NotFound();
				}
				return Ok(loan);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Update details of a specific loan (e.g., extend due date)
		[HttpPut("{id}")]
		public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] LoanDto loanDto)
		{
			try
			{
				var updatedLoan = await _loanRepository.UpdateAsync(id, loanDto);
				if (updatedLoan == null)
				{
					return BadRequest();
				}
				return Ok(updatedLoan);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Return a book (delete a loan)
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var isDeleted = await _loanRepository.DeleteAsync(id);
				if (isDeleted == false)
				{
					return BadRequest();
				}
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
	}
}
