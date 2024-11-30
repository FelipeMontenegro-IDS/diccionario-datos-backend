using System.Data;
using System.Data.SqlClient;
using diccionario_datos.repositories;
using diccionario_datos.repositories.implements;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Habilita la exploración de endpoints
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITableStructureRepository, TableStructureRepository>(); // Scoped
builder.Services.AddScoped<ISchemaRepository, SchemaRepository>(); // Scoped
builder.Services.AddScoped<ITableRepository, TableRepository>(); // Scoped
builder.Services.AddScoped<IReferenceRepository, ReferenceRepository>(); // Scoped

// Configurar acceso a la configuración (opcional, si no ya está configurado)
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Registrar servicios adicionales, si necesitas trabajar con Dapper:
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers(); // Mapea los controladores


app.Run();

