using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Mapper;
using SistemaGimnasio.Repository;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services;
using SistemaGimnasio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//para swager
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//para configurar la base de datos Postgres y obtener la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(entity =>
{
    entity.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

//mapper
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<MapperProfile>();
});




//para repository
//builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();



///**********************************************
builder.Services.AddScoped<IClienteRepositoryRMB, ClienteRepositoryRMB>();

builder.Services.AddScoped<IEntrenadorRepositoryRMB, EntrenadorRepositoryRMB>();
builder.Services.AddScoped<IMembresiaRepositoryRMB, MembresiaRepositoryRMB>();
builder.Services.AddScoped<IPagoRepositoryRMB, PagoRepositoryRMB>();
builder.Services.AddScoped<IClaseRepositoryRMB, ClaseRepositoryRMB>();
builder.Services.AddScoped<IReservaClaseRepositoryRMB, ReservaClaseRepositoryRMB>();
builder.Services.AddScoped<IPlanEntrenamientoRepositoryRMB, PlanEntrenamientoRepositoryRMB>();

//service
//builder.Services.AddScoped<IProductoService,ProductoService>();
//builder.Services.AddScoped<IUsuarioService,UsuarioService>();



///**************************************************************************
builder.Services.AddScoped<IClienteServiceRMB, ClienteServiceRMB>();
builder.Services.AddScoped<IEntrenadorServiceRMB, EntrenadorServiceRMB>();
builder.Services.AddScoped<IMembresiaServiceRMB, MembresiaServiceRMB>();
builder.Services.AddScoped<IPagoServiceRMB, PagoServiceRMB>();
builder.Services.AddScoped<IClaseServiceRMB, ClaseServiceRMB>();
builder.Services.AddScoped<IReservaClaseServiceRMB, ReservaClaseServiceRMB>();
builder.Services.AddScoped<IPlanEntrenamientoServiceRMB, PlanEntrenamientoServiceRMB>();













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
