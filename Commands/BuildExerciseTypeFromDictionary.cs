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
        exerciseType.ExerciseName = this._dataDictionary["ExerciseName"].ToString();
        exerciseType.ExerciseDescription = this._dataDictionary["ExerciseDescription"].ToString();

        return exerciseType;
    }
}