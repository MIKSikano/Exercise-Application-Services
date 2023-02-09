namespace ExerciseApplicationService.Services;

using System.Collections.Generic;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;
using ExerciseApplicationService.Data;

public class WorkoutRecordMSSQLService : IWorkoutRecordService
{
    private readonly DataContext _dataContext;

    public WorkoutRecordMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public void Delete(int Id)
    {
        WorkoutRecord workoutRecord = _dataContext.WorkoutRecords.SingleOrDefault(o => o.Id == Id);
        _dataContext.WorkoutRecords.Remove(workoutRecord);
        _dataContext.SaveChanges();
    }
    

    public List<WorkoutRecord> GetAll()
    {
        return _dataContext.WorkoutRecords.ToList<WorkoutRecord>();
    }

    public WorkoutRecord GetById(int Id)
    {
        return _dataContext.WorkoutRecords.SingleOrDefault(o => o.Id == Id);
    }

    public WorkoutRecord GetLatest() 
    {
        List<WorkoutRecord> workoutRecord = _dataContext.WorkoutRecords.ToList<WorkoutRecord>();
        return workoutRecord.LastOrDefault();
    }

    public void Save(WorkoutRecord hash)
    {
        if (hash.Id == null || hash.Id == 0)
        {
            _dataContext.WorkoutRecords.Add(hash);
        }
        else
        {
            WorkoutRecord tempData = this.GetById(hash.Id);
            tempData.Date = hash.Date;
            tempData.StartTime = hash.StartTime;
            tempData.EndTime = hash.EndTime;
        }
        _dataContext.SaveChanges();
    }
}