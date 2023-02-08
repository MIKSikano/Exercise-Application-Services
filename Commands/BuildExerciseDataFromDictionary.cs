namespace ExerciseApplicationService.Commands;
using ExerciseApplicationService.Models;

public class BuildExerciseDataFromDictionary
{
    private Dictionary<string, object> _dataDictionary;
    public BuildExerciseDataFromDictionary(Dictionary<string, object> data)
    {
        this._dataDictionary = data;
        
    }

    public ExerciseData Run()
    {
        ExerciseData exerciseData = new ExerciseData();

        if (this._dataDictionary.ContainsKey("Id"))
        {
            exerciseData.Id = (int)this._dataDictionary["Id"];
        }
        exerciseData.CaloriesBurned = (int)this._dataDictionary["CaloriesBurned"];
        exerciseData.CaloriesBurnedGoal = (int)this._dataDictionary["CaloriesBurnedGoal"];
        exerciseData.ExerciseTypeId = int.Parse(this._dataDictionary["ExerciseTypeId"].ToString());
        exerciseData.WorkoutRecordId = int.Parse(this._dataDictionary["WorkoutRecordId"].ToString());

        return exerciseData;
    }
}

