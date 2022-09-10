using ItemService.Infrastructure.Configs;
using ItemService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoSettings = builder.Configuration.GetSection("MongoSettings").Get<MongoSettings>();
builder.Services.AddInfrastructure(mongoSettings);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();