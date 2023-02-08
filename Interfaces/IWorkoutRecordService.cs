namespace ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;

public interface IWorkoutRecordService
{
    public List<WorkoutRecord> GetAll();
    public void Save(WorkoutRecord hash);
    public WorkoutRecord GetById(int Id);
    public void Delete(int Id);
}