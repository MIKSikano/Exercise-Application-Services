namespace ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;

public interface IExerciseDataService
{
    public List<ExerciseData> GetAll();
    public void Save(ExerciseData hash);
    public ExerciseData GetById(int Id);
    public void Delete(int Id);
}