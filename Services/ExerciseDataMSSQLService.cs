namespace ExerciseApplicationService.Services;

using System.Collections.Generic;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;
using ExerciseApplicationService.Data;

public class ExerciseDataMSSQLService : IExerciseDataService
{
    private readonly DataContext _dataContext;
    private readonly IExerciseTypeService _exerciseTypeService;
    private readonly IWorkoutRecordService _workoutRecordService;

    public ExerciseDataMSSQLService(DataContext dataContext, IExerciseTypeService exerciseTypeService, IWorkoutRecordService workoutRecordService)
    {
        _dataContext = dataContext;
        _exerciseTypeService = exerciseTypeService;
        _workoutRecordService = workoutRecordService;
    }

    public void Delete(int Id)
    {
        ExerciseData exerciseData = _dataContext.ExerciseDatas.SingleOrDefault(o => o.Id == Id);
        _dataContext.ExerciseDatas.Remove(exerciseData);
        _dataContext.SaveChanges();
    }

    public List<ExerciseData> GetAll()
    {
        List<ExerciseData> exerciseData = _dataContext.ExerciseDatas.ToList<ExerciseData>();
        foreach (ExerciseData item in exerciseData)
        {
            item.ExerciseType = _exerciseTypeService.GetById(item.ExerciseTypeId);
            item.WorkoutRecord = _workoutRecordService.GetById(item.WorkoutRecordId);
        } 
        return exerciseData;
    }

    public ExerciseData GetById(int Id)
    {
        return _dataContext.ExerciseDatas.SingleOrDefault(o => o.Id == Id);;
    }

    public void Save(ExerciseData hash)
    {
        if (hash.Id == null || hash.Id == 0)
        {
            _dataContext.ExerciseDatas.Add(hash);
        } else {
            ExerciseData tempData = this.GetById(hash.Id);
            tempData.CaloriesBurned = hash.CaloriesBurned; 
            tempData.CaloriesBurnedGoal = hash.CaloriesBurnedGoal;
            tempData.ExerciseTypeId = hash.ExerciseTypeId;
            tempData.WorkoutRecordId = hash.WorkoutRecordId;
        }
        _dataContext.SaveChanges();
    }
}