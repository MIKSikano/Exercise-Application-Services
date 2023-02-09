using Microsoft.EntityFrameworkCore;
using ExerciseApplicationService.Data;
using ExerciseApplicationService.Models;
using System.Text.Json.Serialization;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Services;

namespace ExerciseApplicationService;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        var corConfigName = "CORS-Config";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: corConfigName, policy =>
            {
                policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

            });
        });

        builder.Services.AddControllers().AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               options.JsonSerializerOptions.WriteIndented = true;
               options.JsonSerializerOptions.PropertyNamingPolicy = null;
           });

        builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IExerciseDataService, ExerciseDataMSSQLService>();
        builder.Services.AddScoped<IExerciseTypeService, ExerciseTypeMSSQLService>();
        builder.Services.AddScoped<IWorkoutRecordService, WorkoutRecordMSSQLService>();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(corConfigName);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}