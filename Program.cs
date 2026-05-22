////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.

////builder.Services.AddControllers();
////// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//////builder.Services.AddOpenApi();
////// Register TaskServices as a singleton
////builder.Services.AddSingleton<TaskManager.Services.TaskServices>();

//////Swagger service
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var app = builder.Build();

////// Configure the HTTP request pipeline.

////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}


////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

////app.Run();
//var builder = WebApplication.CreateBuilder(args);

//// Add services
//builder.Services.AddControllers();

//// Register TaskService
//builder.Services.AddSingleton<TaskManager.Services.TaskServices>();

//// ✅ Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// ✅ Enable Swagger UI
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using Microsoft.EntityFrameworkCore;
using TaskManager.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register TaskService as scoped so it can safely consume the DbContext (which is scoped).
// Scoped lifetime creates one instance per request, matching the DbContext lifetime.
builder.Services.AddScoped<TaskManager.Services.TaskServices>();

builder.Services.AddDbContext<TaskManager.Model.TaskitemContext>(options => {
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskManagerDB;Trusted_Connection=True;");
});
//create final application object
var app = builder.Build();
//HTTPS redirection is a security feature that automatically redirects HTTP requests to HTTPS. This ensures that all communication between the client and server is encrypted and secure. By using HTTPS, you can protect sensitive data from being intercepted by attackers and improve the overall security of your application.
app.UseHttpsRedirection();

//Authorization is a security mechanism that determines whether a user or client has permission to access a specific resource or perform a certain action. It is typically used in conjunction with authentication, which verifies the identity of the user or client. By using authorization, you can control access to sensitive data and functionality in your application, ensuring that only authorized users can access certain features or perform certain actions.
app.UseAuthorization();
// MapControllers is a method that maps incoming HTTP requests to the appropriate controller actions based on the routing configuration. It allows you to define routes for your API endpoints and ensures that requests are directed to the correct controller methods for processing. By using MapControllers, you can easily create RESTful APIs and handle various HTTP methods (GET, POST, PUT, DELETE) in your application.
//This connects controller routes to the application.
app.MapControllers();

app.Run();