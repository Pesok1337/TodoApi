
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TodoApi.Models;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           // builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            string connectionString = builder.Configuration.GetConnectionString("ToDoContext");
            builder.Services.AddDbContext<TodoContext>(op => op.UseNpgsql(connectionString));
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage(); // old

            }
            app.UseDefaultFiles(); // old
            app.UseStaticFiles(); // old

            app.UseRouting();



            app.UseHttpsRedirection();

            app.UseAuthorization();


            //app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}