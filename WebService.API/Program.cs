using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
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

_builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions
{
	Credential = GoogleCredential.FromFile(
		Directory.GetCurrentDirectory() +
		"/Service/Firebase/webservice-eeaaa-firebase-adminsdk-25j7s-2f07f228d8.json"),
	ProjectId = "1:350339673774:web:ad803bae26f55267a8c73f"
}));

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