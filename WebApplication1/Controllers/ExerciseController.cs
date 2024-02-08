using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateExerciseDTO requestDto)
        {
            var exercise = new Exercises
            {
                Name = requestDto.Name,
                Description = requestDto.Description,
                CreatedAt = requestDto.CreatedAt,
            };

            await exerciseRepository.CreateAsync(exercise);

            var response = new ExercisesDTO
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                CreatedAt = exercise.CreatedAt,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await exerciseRepository.GetAllAsync();

            var response = new List<ExercisesDTO>();

            foreach (var exercise in exercises)
            {
                response.Add(new ExercisesDTO
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    Description = exercise.Description,
                    CreatedAt = exercise.CreatedAt,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var existingExercise = await exerciseRepository.GetById(id);

            if (existingExercise == null)
            {
                return NotFound();
            }

            var response = new ExercisesDTO
            {
                Id = existingExercise.Id,
                Name = existingExercise.Name,
                Description = existingExercise.Description,
                CreatedAt = existingExercise.CreatedAt,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateExerciseDTO request)
        {
            var exercise = new Exercises
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                CreatedAt = request.CreatedAt,
            };

            exercise = await exerciseRepository.UpdateAsync(exercise);

            if (exercise == null)
            {
                return NotFound();
            }

            var response = new ExercisesDTO
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            var existingExercise = await exerciseRepository.DeleteAsync(id);

            if (existingExercise == null)
            {
                return NotFound();
            }

            var response = new ExercisesDTO
            {
                Id = existingExercise.Id,
                Name = existingExercise.Name,
                Description = existingExercise.Description,
                CreatedAt = existingExercise.CreatedAt,
            };

            return Ok(response);
        }
    }
}
