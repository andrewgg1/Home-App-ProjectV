using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Enable Swagger for API testing

// Add CORS policy to allow requests from any origin (for testing purposes)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Allow requests from any origin
              .AllowAnyMethod() // Allow all HTTP methods (GET, POST, PUT, DELETE)
              .AllowAnyHeader(); // Allow all headers
    });
});

var app = builder.Build();

// Bind to all network interfaces (required for Emulator or remote testing)
app.Urls.Add("http://0.0.0.0:5069");

// Dynamically configure settings based on environment
if (app.Environment.IsDevelopment())
{
    // Development: Enable Swagger UI for API testing
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1 (Development)");
    });
}
else
{
    // Production: Bind to all interfaces
    app.Urls.Add("http://0.0.0.0:80"); // Required for Docker or production environments
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1 (Production)");
        c.RoutePrefix = string.Empty; // Serve Swagger at root (e.g., http://host/)
    });
}

// Enable CORS for all routes
app.UseCors();

// Enable HTTPs redirection (uncomment if required later in production)
// app.UseHttpsRedirection();

app.UseAuthorization();

// Map all controller routes
app.MapControllers();

// Start the application
app.Run();
