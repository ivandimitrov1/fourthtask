using Microsoft.EntityFrameworkCore;
using Fourth.Application;
using Fourth.Infrastructure;

Console.WriteLine("Starting web api ...");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var allowedHosts = builder.Configuration["CorsAllowedHosts"].Split(";");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins",
        policy =>
        {
            policy.SetIsOriginAllowed(origin => allowedHosts.Contains(new Uri(origin).Host))
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowedOrigins");

app.Run();

public partial class Program { }