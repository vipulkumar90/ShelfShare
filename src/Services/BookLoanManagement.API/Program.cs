
using BookLoanManagement.API.DataContext;
using BookLoanManagement.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookLoanManagement.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddScoped<ILoanRepository, LoanRepository>();
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddDbContext<BookLoanManagementContext>(options =>
				options.UseInMemoryDatabase("BookLoanManagementDb"));
			var options = new DbContextOptionsBuilder<BookLoanManagementContext>()
			.UseInMemoryDatabase("BookLoanManagementDb").Options;
			using (var context = new BookLoanManagementContext(options))
			{
				context.Database.EnsureCreated();
			}
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
