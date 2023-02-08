namespace ExerciseApplicationService.Data;
using Microsoft.EntityFrameworkCore;
using ExerciseApplicationService.Models;

public class DataContext : DbContext
{
    public DbSet<ExerciseData> ExerciseDatas {get; set;}
    public DbSet<ExerciseType> ExerciseTypes {get; set;}
    public DbSet<WorkoutRecord> WorkoutRecords {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseData>()
            .HasOne(d => d.ExerciseType)
            .WithMany(t => t.ExerciseDatas);

        modelBuilder.Entity<ExerciseData>()
            .HasOne(d => d.WorkoutRecord)
            .WithMany(w => w.ExerciseDatas);
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}