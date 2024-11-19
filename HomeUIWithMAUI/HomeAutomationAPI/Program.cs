using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Enable Swagger for API testing

var app = builder.Build();

// Dynamically bind to the correct URLs based on the environment
if (app.Environment.IsDevelopment())
{
    // Development: Use the default Kestrel settings (localhost)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1 (Development)");
    });
}
else
{
    // Production (e.g., Docker): Bind to all network interfaces
    app.Urls.Add("http://0.0.0.0:80"); // Required for Docker
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1 (Production)");
        c.RoutePrefix = string.Empty; // Serve Swagger at root (http://localhost:8080/)
    });
}

app.UseHttpsRedirection(); // Optional: Redirect HTTP to HTTPS
app.UseAuthorization();
app.MapControllers();
app.Run();
