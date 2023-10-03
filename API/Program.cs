using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args); //create our website app instance

// Add services to the container. - when creating a service we must add an interface

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication(); //do you have a valid token?   are you alowed in the night club?
app.UseAuthorization(); // You have a valid token what are you alowed to do?    yes you are 21 you can go in!

app.MapControllers();

app.Run(); //run that shit
