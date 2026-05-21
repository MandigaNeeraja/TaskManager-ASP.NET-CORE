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
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register TaskService
builder.Services.AddSingleton<TaskManager.Services.TaskServices>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();