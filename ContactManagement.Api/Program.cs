using ContactManagement.Api.Models;
using ContactManagement.Api.Repository;
using ContactManagement.Api.Controllers;
using ContactManagement.Api.WebApiHelpers;
using NLog.Web;
using NLog.Extensions.Logging;


//var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
//builder.Services.AddCors(options=>
//{
//options.AddDefaultPolicy;
//options.AddPolicy(name: "contactapp", configurePolicy: policyBuilder =>
//{
//    policyBuilder.WithOrigins("http://localhost:4200/");
//    policyBuilder.AllowAnyHeader();
//    policyBuilder.AllowAnyMethod();
//    policyBuilder.AllowCredentials();
//});
//});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
});

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
app.UseCors();
app.UseMiddleware<GlobalExceptionMidleware>();
app.Run();