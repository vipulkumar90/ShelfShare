
using BookCatalog.API.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddDbContext<BookCatalogContext>(options =>
				options.UseInMemoryDatabase("BookCatalogDb"));
			var options = new DbContextOptionsBuilder<BookCatalogContext>()
			.UseInMemoryDatabase("BookCatalogDb").Options;
			using (var context = new BookCatalogContext(options))
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
