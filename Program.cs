using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Reflection;
using Todo.Data;
using Todo.Options;
using Todo.Services;

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
            Name = "Joao Paulo / Hézio Silva",
            Email = "jpc0848@gmail.com",
        },
        Description = "Para mais informações, visite:\n" +
                      "- LinkedIn: [Joao Paulo](https://www.linkedin.com/in/joaopaulo04/) | Github: [link](https://github.com/piressjp)\n" +
                      "- LinkedIn: [Hézio Silva](https://www.linkedin.com/in/hezio-silva/) | Github: [link](https://github.com/HezioS1lv4)"
    });



    var xmlFile = "Todo.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddScoped<ITokenService, TokenService>();

// Add authentication
var key = Encoding.ASCII.GetBytes(JWTConfiguration.JWTKey);
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
    })
    .AddJwtBearer(x =>
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        } 
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add autenticação ao swagger
    var jwtSewcurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }

    };

    c.AddSecurityDefinition(jwtSewcurityScheme.Reference.Id, jwtSewcurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSewcurityScheme, Array.Empty<string>() }
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Desenvolvimento");
    options.RoutePrefix = string.Empty; // Para exibir a UI na raiz do domínio
});

app.MapControllers();

app.Run();
