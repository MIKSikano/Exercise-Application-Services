namespace ExerciseApplicationService.Commands;
using ExerciseApplicationService.Models;

public class BuildWorkoutRecordFromDictionary
{
    private readonly Dictionary<string, object> _dataDictionary;

    public BuildWorkoutRecordFromDictionary(Dictionary<string, object> data)
    {
        this._dataDictionary = data;
    }

    public WorkoutRecord Run()
    {
        WorkoutRecord workoutRecord = new WorkoutRecord();
        if (this._dataDictionary.ContainsKey("Id"))
        {
            workoutRecord.Id = (int)this._dataDictionary["Id"];
        }
        workoutRecord.Date = DateTime.Parse(this._dataDictionary["Date"].ToString());
        workoutRecord.StartTime = DateTime.Parse(this._dataDictionary["StartTime"].ToString());
        workoutRecord.EndTime = DateTime.Parse(this._dataDictionary["EndTime"].ToString());
        
        return workoutRecord;
    }

}