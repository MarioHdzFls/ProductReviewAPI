using Microsoft.AspNetCore.Builder;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Services;
using ProductReviewAPI.Utils;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policyBuilder =>
    {
        if (builder.Environment.IsDevelopment())
        {
            policyBuilder.WithOrigins("https://localhost")
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        }
        else
        {
            policyBuilder.WithOrigins("https://example.com") // Cambia esto a tu dominio de producción
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        }
    });
});
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IAIProvider, SimulatedAIProvider>();
builder.Services.AddScoped<SimulatedAIProvider>();
builder.Services.AddScoped<ExternalAIProvider>();
builder.Services.AddSingleton<AIProviderFactory>();
builder.Services.AddSingleton<SentimentHelper>(provider =>
    new SentimentHelper(new List<string> { "excelente", "bueno", "positivo", "maravilloso" },
                        new List<string> { "malo", "terrible", "negativo", "horrible" }));


var logger = new LoggerConfiguration()
   .WriteTo.Console() // Requiere el paquete NuGet "Serilog.Sinks.Console"
   .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
   .CreateLogger();

builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelAttribute)); // Cambiar a 'typeof' para pasar el tipo en lugar de la instancia
});
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
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductReviewAPI v1");
        options.RoutePrefix = string.Empty; // Acceso desde la raíz
    });
}

    app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
