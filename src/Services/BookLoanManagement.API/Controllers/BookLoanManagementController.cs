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
		private readonly ILogger<BookLoanManagementController> _logger;
		private readonly string _logContext = $"[{typeof(BookLoanManagementController).Name}]";
		public BookLoanManagementController(ILoanRepository loanRepository, ILogger<BookLoanManagementController> logger)
        {
            _loanRepository = loanRepository;
			_logger = logger;
        }
        //Borrow a book (create a book loan)
        [HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] LoanDto loanDto)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Creating a book loan entry");
				var loanId = await _loanRepository.CreateAsync(loanDto);
				_logger.LogInformation($"{_logContext} Book loan with id:{loanId} has been created.");
				return Created();
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Retrieve the list of loans
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Loan>>> GetAsync() 
		{
			try
			{
				_logger.LogInformation($"{_logContext} Getting all book loans");
				var loans = await _loanRepository.ReadAsync();
				_logger.LogInformation($"{_logContext} Retrieved all book loans");
				return Ok(loans);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Retrieve details of a specific loan
		[HttpGet("{id}")]
		public async Task<ActionResult<Loan>> GetAsync(Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logContext} Getting book loan with id:{id}");
				var loan = await _loanRepository.ReadAsync(id);
				if (loan == null)
				{
					_logger.LogInformation($"{_logContext} Book loan with id:{id} is not found");
					return NotFound();
				}
				_logger.LogInformation($"{_logContext} Book loan with id:{id} fetched successfully");
				return Ok(loan);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Update details of a specific loan (e.g., extend due date)
		[HttpPut("{id}")]
		public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] LoanDto loanDto)
		{
			try
			{
				_logger.LogInformation($"{_logger} Updating a book loan with id:{id}");
				var updatedLoan = await _loanRepository.UpdateAsync(id, loanDto);
				if (updatedLoan == null)
				{
					_logger.LogInformation($"{_logContext} Book loan with id:{id} doesn't exist");
					return BadRequest();
				}
				_logger.LogInformation($"{_logContext} Updated book loan with id:{id} successfully");
				return Ok(updatedLoan);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
		//Return a book (delete a loan)
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				_logger.LogInformation($"{_logger} Deleting a book loan with id:{id}");
				var isDeleted = await _loanRepository.DeleteAsync(id);
				if (isDeleted == false)
				{
					_logger.LogInformation($"{_logContext} Book loan with id:{id} doesn't exist");
					return BadRequest();
				}
				_logger.LogInformation($"{_logContext} Deleted book loan with id:{id} successfully");
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError($"{_logContext} Internal error: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
	}
}
