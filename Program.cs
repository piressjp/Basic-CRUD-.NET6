using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System.Reflection;
using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Joao Paulo", 
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Desenvolvimento");
    options.RoutePrefix = string.Empty; // Para exibir a UI na raiz do domínio
});

app.MapControllers();

app.Run();
