using Dsw2025Ej14.Api.Data;
using Dsw2025Ej14.Api.Interfaces;
using Dsw2025Ej14.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);
// Add Dependency Inyection
builder.Services.AddSingleton<IPersistenciaEnMemoria, PersistenciaEnMemoria>();
// Add services to the container.
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
