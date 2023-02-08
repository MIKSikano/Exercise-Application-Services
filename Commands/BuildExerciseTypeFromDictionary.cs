namespace ExerciseApplicationService.Commands;
using ExerciseApplicationService.Models;

public class BuildExerciseTypeFromDictionary
{
    private Dictionary<string, object> _dataDictionary;
    public BuildExerciseTypeFromDictionary(Dictionary<string, object> data)
    {
        this._dataDictionary = data;
    }

    public ExerciseType Run()
    {
        ExerciseType exerciseType = new ExerciseType();
        if (this._dataDictionary.ContainsKey("Id"))
        {
            exerciseType.Id = (int)this._dataDictionary["Id"];
        }
        exerciseType.ExerciseName = (string)this._dataDictionary["ExerciseName"];
        exerciseType.ExerciseName = (string)this._dataDictionary["ExerciseDesciption"];

        return exerciseType;
    }
}