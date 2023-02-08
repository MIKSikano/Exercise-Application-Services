namespace ExerciseApplicationService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;
using ExerciseApplicationService.Commands;

[ApiController]
[Route("exercise_data")]
public class ExerciseDataController : ControllerBase
{
    private readonly IExerciseDataService _exerciseDataService;

    public ExerciseDataController(IExerciseDataService exerciseDataService)
    {
        _exerciseDataService = exerciseDataService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<ExerciseData> exerciseData = _exerciseDataService.GetAll();
        return Ok(exerciseData);
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveExerciseData validator = new ValidateSaveExerciseData(hash);
        validator.ValidateSave();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            var cmd = new BuildExerciseDataFromDictionary(hash);
            ExerciseData exerciseData = cmd.Run();
            _exerciseDataService.Save(exerciseData);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Workout Data Added");
            return Ok(message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        ExerciseData exerciseData = _exerciseDataService.GetById(id);
        return Ok(exerciseData);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _exerciseDataService.Delete(id);
        return Ok("Workout Data is Deleted");
    }

}