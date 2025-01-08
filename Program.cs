
using Microsoft.EntityFrameworkCore;
using SanctionManagingBackend.ApplicationLayer.Interface;
using SanctionManagingBackend.ApplicationLayer.Service;
using SanctionManagingBackend.DAL.Interface;
using SanctionManagingBackend.DAL.Repository;
using SanctionManagingBackend.Data.DBcontext;
using SanctionManagingBackend.Data.Entity;
using SanctionManagingBackend.DTO;
using System;

namespace SanctionManagingBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<SanctionContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                {
                    builder.WithOrigins("http://localhost:8080") // Vervang door je frontend URL
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            RegisterInterfaces(builder);
            var app = builder.Build();



            app.UseMiddleware<ExceptionHandlingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegisterInterfaces(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            builder.Services.AddScoped<IFlexworkerRepository, FlexworkerRepository>();
            builder.Services.AddScoped<IFlexworkerService, FlexworkerService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ISanctionRepository, SanctionRepository>();
            builder.Services.AddScoped<ISanctionService, SanctionService>();
            builder.Services.AddScoped<ISanctionTypeRepository, SanctionTypeRepository>();
            builder.Services.AddScoped<ISanctionTypeService, SanctionTypeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
