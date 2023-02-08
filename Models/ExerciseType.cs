namespace ExerciseApplicationService.Models;

public class ExerciseType
{
    public int Id {get; set;}
    public string ExerciseName {get; set;}
    public string ExerciseDescription {get; set;}
    public List<ExerciseData> ExerciseDatas {get; set;}
}