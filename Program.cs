using Swashbuckle.Swagger;
using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Desenvolvimento");
    options.RoutePrefix = string.Empty; // Para exibir a UI na raiz do domínio
});

app.MapControllers();

app.Run();
