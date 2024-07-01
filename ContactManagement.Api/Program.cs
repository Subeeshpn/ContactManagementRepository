using ContactManagement.Api.Models;
using ContactManagement.Api.Repository;
using ContactManagement.Api.Controllers;
using ContactManagement.Api.WebApiHelpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

var services = builder.Services;
services.AddScoped<IContactRepository, ContactRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=GetAllContact}/{id?}");
}
app.UseExceptionHandlerMiddleware();
app.UseHttpsRedirection();
app.Run();