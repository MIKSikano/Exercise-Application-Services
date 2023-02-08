namespace ExerciseApplicationService.Services;

using System.Collections.Generic;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;
using ExerciseApplicationService.Data;

public class ExerciseTypeMSSQLService : IExerciseTypeService
{
    private readonly DataContext _dataContext;

    public ExerciseTypeMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public void Delete(int Id)
    {
        ExerciseType exerciseType = _dataContext.ExerciseTypes.SingleOrDefault(o => o.Id == Id);
        _dataContext.ExerciseTypes.Remove(exerciseType);
        _dataContext.SaveChanges();
    }

    public List<ExerciseType> GetAll()
    {
        return _dataContext.ExerciseTypes.ToList<ExerciseType>();
    }

    public ExerciseType GetById(int Id)
    {
        return _dataContext.ExerciseTypes.SingleOrDefault(o => o.Id == Id);
    }

    public void Save(ExerciseType hash)
    {
        if (hash.Id == null || hash.Id == 0)
        {
            _dataContext.ExerciseTypes.Add(hash);
        }
        else
        {
            ExerciseType tempData = this.GetById(hash.Id);
            tempData.ExerciseName = hash.ExerciseName;
            tempData.ExerciseDescription = hash.ExerciseDescription;
        }
        _dataContext.SaveChanges();
    }
}