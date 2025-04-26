using Backend.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using GenericServices.PublicButHidden;
using GenericServices;
using GenericServices.Configuration;
using System.Reflection;
using GenericServices.Setup;
using Backend.Dtos;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


builder.Services.GenericServicesSimpleSetup<AppDbContext>(
    new GenericServicesConfig
    {
        DtoAccessValidateOnSave = true,  //This causes validation to happen on create/update via DTOs
        DirectAccessValidateOnSave = true, //This causes validation to happen on direct create/update and delete
        NoErrorOnReadSingleNull = true //When working with WebAPI you should set this flag. Responce then sends 404 on null result;
    }, Assembly.GetAssembly(typeof(ClientCompanyDto)));


builder.Services.AddSwaggerGen(c =>
 {
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API V1", Version = "v1" });

 });

 // Add services to the container.

 builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Set to an empty string for Swagger UI at the root (localhost:5000)
    });
}


app.UseAuthorization();

app.MapControllers();

app.Run();
