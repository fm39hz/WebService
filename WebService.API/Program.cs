using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Context;

var _builder = WebApplication.CreateBuilder(args);

var _service = _builder.Services;
var _configuration = _builder.Configuration;
// Add services to the container.
_service.AddControllers();
_service.AddDbContext<DataContext>(options => options.UseSqlServer(
	_configuration.GetConnectionString("DataContext"),
	optionsBuilder => optionsBuilder.EnableRetryOnFailure(
		3,
		TimeSpan.FromSeconds(5),
		null)));
_service.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
{
	ApiKey = _configuration.GetValue<string>("ApiKey"),
	AuthDomain = _configuration.GetValue<string>("AuthDomain"),
	Providers = new FirebaseAuthProvider[]
	{
		new EmailProvider()
	}
}));
_service.AddSingleton(FirebaseApp.Create(new AppOptions
{
	Credential = GoogleCredential.FromFile(
		Directory.GetCurrentDirectory() +
		_configuration.GetValue<string>("CredentialFile")),
	ProjectId = _configuration.GetValue<string>("ProjectId")
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_service.AddEndpointsApiExplorer();
_service.AddSwaggerGen();


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