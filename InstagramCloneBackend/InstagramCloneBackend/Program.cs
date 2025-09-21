using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger/OpenAPI servislerini ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Instagram Clone API",
        Version = "v1",
        Description = "Flutter uygulamas� i�in backend API"
    });
});

var app = builder.Build();

// Swagger UI�yi sadece Development ortam�nda a�
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Instagram Clone API V1");
        c.RoutePrefix = string.Empty; // localhost:5000 direkt swagger a�ar
    });
}



app.UseAuthorization();

app.MapControllers();

app.Run();
