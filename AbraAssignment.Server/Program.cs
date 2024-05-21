using AbraAssignment.Server.Config;
using AbraAssignment.Server.Models;
using AbraAssignment.Server.Repositories;
using AbraAssignment.Server.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoSettings = builder.Configuration.GetSection("MongoSettings").Get<MongoSettings>();

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
	new MongoClient(mongoSettings?.ConnectionString));

builder.Services.AddScoped<IRepository<Pet>>(sp =>
	new MongoRepository<Pet>(
		sp.GetRequiredService<IMongoClient>(),
		mongoSettings.DatabaseName,
		mongoSettings.PetsCollectionName
	));

builder.Services.AddScoped<PetService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
