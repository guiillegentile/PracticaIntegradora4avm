using Microsoft.EntityFrameworkCore;
using PracticaIntegradora4.Repositories.Implementations;
using PracticaIntegradora4.Repositories.Interfaces;
using PracticaIntegradora4.Services.Implementations;
using PracticaIntegradora4.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Agregamos esto para que Swagger funcione
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<PracticaIntegradora4.Data.Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Habilitamos la interfaz de Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();