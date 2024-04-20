using RoomMicroservices.Infrastructure;
using RoomMicroservices.Persistence;
using RoomMicroservices.Application;
using RoomMicroservices.API.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigurePersistenceServices(builder.Configuration, builder.Environment);
builder.Services.ConfigureInfrastructureServices(builder.Configuration, builder.Environment);
builder.Services.ConfigureApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
//app.UseHttpsRedirection();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
