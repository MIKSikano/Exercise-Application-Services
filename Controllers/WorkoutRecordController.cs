namespace ExerciseApplicationService.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ExerciseApplicationService.Interfaces;
using ExerciseApplicationService.Models;
using ExerciseApplicationService.Commands;

[ApiController]
[Route("workout_record")]
public class WorkoutRecordController : ControllerBase
{
    private readonly IWorkoutRecordService _workoutRecordService;

    public WorkoutRecordController(IWorkoutRecordService workoutRecordService)
    {
        _workoutRecordService = workoutRecordService;
    }


    [HttpGet("")]
    public IActionResult Index()
    {
        List<WorkoutRecord> workoutRecord = _workoutRecordService.GetAll();
        return Ok(workoutRecord);
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveWorkoutRecord validator = new ValidateSaveWorkoutRecord(hash);
        validator.ValidateSave();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            var cmd = new BuildWorkoutRecordFromDictionary(hash);
            WorkoutRecord workoutRecord = cmd.Run();
            _workoutRecordService.Save(workoutRecord);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Workout Record Added!");
            return Ok(message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        WorkoutRecord workoutRecord = _workoutRecordService.GetById(id);
        return Ok(workoutRecord);
    }

    [HttpGet("latest")]
    public IActionResult ShowLatest()
    {
        WorkoutRecord workoutRecord = _workoutRecordService.GetLatest();
        return Ok(workoutRecord);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _workoutRecordService.Delete(id);
        return Ok("Workout Type Deleted!");
    }
}