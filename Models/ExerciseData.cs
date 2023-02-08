namespace ExerciseApplicationService.Models;

public class ExerciseData 
{
    public int Id {get; set;}
    public int CaloriesBurned {get; set;}
    public int CaloriesBurnedGoal {get; set;}
    public int ExerciseTypeId {get; set;}
    public ExerciseType ExerciseType {get; set;}
    public int WorkoutRecordId {get; set;}
    public WorkoutRecord WorkoutRecord {get; set;}
}