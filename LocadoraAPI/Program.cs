using LocadoraAPI.Context;
using LocadoraAPI.Repositories;
using LocadoraAPI.Repositories.Interfaces;
using LocadoraAPI.Services;
using LocadoraAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var sqliteConnectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<LocadoraDBContext>(opt => opt.UseSqlite(sqliteConnectionString));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<ILocacaoService, LocacaoService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
