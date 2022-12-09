using Microsoft.EntityFrameworkCore;
using LibraryApplication.Infrastructure.Context;
using LibraryApplication.API.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

const string CONNSTRING = "LibraryApplication";
var connectionString = builder.Configuration.GetConnectionString(CONNSTRING);

// Add services to the container.

builder.Services.AddDbContext<LibraryApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

builder.Services.ResolveDependencies();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "LibraryApplication API",
        Version = "v1"
    });
});

// Cors Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
