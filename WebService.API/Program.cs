using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;

var _builder = WebApplication.CreateBuilder(args);

// Add services to the container.

_builder.Services.AddControllers();
_builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
	_builder.Configuration.GetConnectionString("DataContext"),
	optionsBuilder => optionsBuilder.EnableRetryOnFailure(
		3,
		TimeSpan.FromSeconds(5),
		null)));

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
// var _firebaseCredentials =
// 	GoogleCredential.FromFile(
// 		Directory.GetCurrentDirectory() +
// 		"/FirebaseConfig/client_secret_62748980710-rgotd8v0p88pv9sq9rb3vhnkp4qneoj4.apps.googleusercontent.com.json");
// var firebaseApp = FirebaseApp.Create(new AppOptions
// {
// 	Credential = _firebaseCredentials,
// 	ProjectId = "62748980710-rgotd8v0p88pv9sq9rb3vhnkp4qneoj4.apps.googleusercontent.com"
// });
_app.UseHttpsRedirection();

_app.UseAuthorization();

_app.MapControllers();

_app.Run();