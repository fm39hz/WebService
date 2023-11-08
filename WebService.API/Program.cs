using Microsoft.EntityFrameworkCore;
using WebService.API.Models;

var _builder = WebApplication.CreateBuilder(args);

// Add services to the container.

_builder.Services.AddControllers();
_builder.Services.AddDbContext<ItemDbContext>(options => options.UseSqlServer( 
		_builder.Configuration.GetConnectionString("ItemContext"),
	optionsBuilder => optionsBuilder.EnableRetryOnFailure(
		maxRetryCount: 3,
		maxRetryDelay: TimeSpan.FromSeconds(5),
		errorNumbersToAdd: null)
		));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_builder.Services.AddEndpointsApiExplorer();
_builder.Services.AddSwaggerGen();

var _app = _builder.Build();

// Configure the HTTP request pipeline.
if (_app.Environment.IsDevelopment())
{
	_app.UseSwagger();
	_app.UseSwaggerUI();
}

_app.UseHttpsRedirection();

_app.UseAuthorization();

_app.MapControllers();

_app.Run();