using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EProducts.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EProductsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EProductsContext") ?? throw new InvalidOperationException("Connection string 'EProductsContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(p=>p.AddPolicy("corspolicy",bulid=>
{
    bulid.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();

}));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
