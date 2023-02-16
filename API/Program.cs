using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// services are used to add functionality to the application and are added to the IServiceCollection that is passed to the Configure method. 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); // this is the connection string to the database (DefaultConnection)
});
builder.Services.AddCors(opt => 
{
    opt.AddPolicy("CorsPolicy", policy => 
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"); // this is the policy that is used to allow requests from the client
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// The request pipeline is a series of middleware components that are invoked in a particular order to handle requests and return responses.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy"); // this is the cors middleware that is used to allow requests from the client

app.UseAuthorization(); // this is the authorization middleware that is used to authorize requests

app.MapControllers(); // this is the routing middleware that is used to route requests to the appropriate controller
 
using var scoper = app.Services.CreateScope(); // this is the service scope that is used to create a scope for the services that are used in the application
var services = scoper.ServiceProvider; // this is the service provider that is used to get the services that are used in the application

try{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
