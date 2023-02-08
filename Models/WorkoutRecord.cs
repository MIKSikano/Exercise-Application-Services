namespace ExerciseApplicationService.Models;

public class WorkoutRecord
{
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}
    public List<ExerciseData> ExerciseDatas {get; set;}
}