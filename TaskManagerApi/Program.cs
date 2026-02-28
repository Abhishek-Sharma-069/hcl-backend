// It is same like index.ts in nodejs


// bring models into scope so the `WeatherForecast` record is visible
using TaskManagerApi; // same as import/require in nodejs
using TaskManagerApi.Services;

// `WebApplication.CreateBuilder` sets up the basic infrastructure for
// an ASP.NET Core application such as configuration, logging, and
// dependency injection. The `args` come from the command line.
var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------
// Services
// ------------------------------------------------------------------
// Services are components that can be injected into other parts of your
// app (controllers, endpoints, etc.). Here we add OpenAPI/Swagger support
// so that a UI is available for testing endpoints when running locally.
// You can remove this if you're not interested in API documentation.
// Learn more: https://aka.ms/aspnet/openapi
builder.Services.AddControllers(); // Register controllers
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // Add this line
builder.Services.AddScoped<ITaskItemService, TaskItemService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();

// ------------------------------------------------------------------
// Middleware / HTTP request pipeline
// ------------------------------------------------------------------
// Middleware components are run in the order they are added. The
// pipeline below is very simple: if we're in development mode we
// enable the Swagger UI, then force HTTPS, then register our endpoints.
// if (app.Environment.IsDevelopment())
// {
//     // exposes /swagger and /swagger/index.html when running locally
//     app.MapOpenApi();
// }
app.UseCors("AllowAll");
app.MapControllers(); // Add this line to enable attribute routing for controllers
app.MapOpenApi();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();           // Add this
    app.UseSwaggerUI();         // Add this
}

// Redirect HTTP requests to HTTPS automatically (useful for security).
//app.UseHttpsRedirection();

// Example data used by the sample endpoint below. In a real app you
// would typically retrieve this from a database or external service.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", () => "Hello World! Welcome to ASP.NET Core!");
// `MapGet` creates a minimal API endpoint that responds to HTTP GET
// requests at the given path ("/weatherforecast"). The second parameter
// is a lambda that returns the response body. Minimal APIs are great for
// newcomers because you don't need controllers or much ceremony.


app.MapGet("/hello/{name}", (string name) =>
{
    var welcome = $"Hello, {name}! Welcome to ASP.NET Core!";
    return welcome;
});

app.Run();
