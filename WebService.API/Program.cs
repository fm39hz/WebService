using Firebase.Auth;
using Firebase.Auth.Providers;
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
_builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
{
	ApiKey = "AIzaSyCrHSc5RMJHaLxxJPRElqG8kri-NcflwXE",
	AuthDomain = "webservice-eeaaa.firebaseapp.com",
	Providers = new FirebaseAuthProvider[]
	{
		new EmailProvider()
	}
}));
_builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions
{
	Credential = GoogleCredential.FromFile(
		Directory.GetCurrentDirectory() +
		"/Service/Firebase/webservice-eeaaa-firebase-adminsdk-25j7s-2f07f228d8.json"),
	ProjectId = "webservice-eeaaa"
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