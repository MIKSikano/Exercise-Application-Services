namespace ExerciseApplicationService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;
using ExerciseApplicationService.Commands;

[ApiController]
[Route("exercise_type")]
public class ExerciseTypeController : ControllerBase
{
    private readonly IExerciseTypeService _exerciseTypeService;

    public ExerciseTypeController(IExerciseTypeService exerciseTypeService)
    {
        _exerciseTypeService = exerciseTypeService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<ExerciseType> exerciseType = _exerciseTypeService.GetAll();
        return Ok(exerciseType);
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveExerciseType validator = new ValidateSaveExerciseType(hash);
        validator.ValidateSave();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            var cmd = new BuildExerciseTypeFromDictionary(hash);
            ExerciseType exerciseType = cmd.Run();
            _exerciseTypeService.Save(exerciseType);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Workout Type Added!");
            return Ok(message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        ExerciseType exerciseType = _exerciseTypeService.GetById(id);
        return Ok(exerciseType);
    }

    [HttpGet("latest")]
    public IActionResult ShowLatest()
    {
        ExerciseType exerciseType = _exerciseTypeService.GetLatest();
        return Ok(exerciseType);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _exerciseTypeService.Delete(id);
        return Ok("Workout Type Deleted!");
    }
}