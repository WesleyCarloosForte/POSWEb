using Backend.Data;
using SharedProject.Interface;
using SharedProject.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26))); // Reemplaza la versión de MySQL con tu versión específica
});


builder.Services.AddAutoMapper(typeof(Backend.AutoMapper.MappingProfiles));


builder.Services.AddTransient<IRolRepository,RolRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IVentaRepository, VentaRepository>();
builder.Services.AddTransient<IProveedorRepository, ProovedorRepository>();
builder.Services.AddTransient<ICompraRepository, CompraRepository>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<INumeracionComprobanteRepository, NumeracionComprobanteRepository>();
builder.Services.AddTransient<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddTransient<IRolRepository, RolRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configurar CORS para cualquier origen
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
