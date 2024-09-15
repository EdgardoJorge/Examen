using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ExamenData.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

String con = "data Source=DESKTOP-J34L8LH;Initial Catalog=ExamenDb;Integrated Security=true; TrustServerCertificate=True";
builder.Services.AddDbContext<MiDbContext>(
    conf => conf.UseSqlServer(
        con,
        b => b.MigrationsAssembly("Examen"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
