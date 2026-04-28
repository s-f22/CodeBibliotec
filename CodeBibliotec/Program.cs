using CodeBibliotec.Context;
using CodeBibliotec.Interfaces;
using CodeBibliotec.Repositories;
using CodeBibliotec.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);



// Pegando a connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrando o DbContext
builder.Services.AddDbContext<BibliotecContext>(options => options.UseSqlServer(connectionString));

// Registra dependencias (injeção de dependencias)
// onde AddScoped define que uma nova instancia do servico será criada para cada requisição HTTP; Também é feita a associação entre as interfaces e suas respectivas implementações
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();


// Add services to the container.

// Add Serialização para evitar erros de ciclo
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add JWT authentication to Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Input your Bearer token in this format - Bearer {your token here} to access this API"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });


});

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
