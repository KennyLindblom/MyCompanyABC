
using Microsoft.OpenApi.Models;
using MyCompanyABC.Models;
using MyCompanyABC.Repositories;

namespace MyCompanyABC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "Asp.Net Core Swagger API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.DocumentTitle = "Learning minimal API";
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", name: "Api that gives you a possibility to learn.");
                swaggerUiOptions.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/get-all-employees", async () => await EmployeeRepository.GetEmployeeAsync())
                .WithTags("Employees endpoint");

            app.MapGet("/get-employee-by-id/{employeeId}", handler: async (int employeeId) =>
            {
                Employee employee = await EmployeeRepository.GetEmployeeByIdAsync(employeeId);
                if (employee != null)
                {
                    return Results.Ok(employee);
                }
                else 
                {
                    return Results.BadRequest(); 
                }
            }).WithTags("Employees endpoint");
            //*****************************************
            app.MapPost("/create-employee", handler: async (Employee employee) =>
            {
                bool createSuccess = await EmployeeRepository.CreateEmployeeAsync(employee);
                if (createSuccess)
                {
                    return Results.Ok("Employee created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees endpoint");

            app.Run();
        }
    }
}