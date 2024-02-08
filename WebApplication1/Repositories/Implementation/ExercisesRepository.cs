using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementation
{
    public class ExercisesRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExercisesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Exercises> CreateAsync(Exercises exercises)
        {
            await dbContext.Exercises.AddAsync(exercises);
            await dbContext.SaveChangesAsync();
            return exercises;
        }

        public async Task<IEnumerable<Exercises>> GetAllAsync()
        {
            return await dbContext.Exercises.ToListAsync();
        }

        public async Task<Exercises?> GetById(Guid id)
        {
            return await dbContext.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
        }

        public async Task<Exercises?> UpdateAsync(Exercises exercises)
        {
            var existingExercise = await dbContext.Exercises.FirstOrDefaultAsync(ex => ex.Id == exercises.Id);
            
            if (existingExercise != null)
            {
                dbContext.Entry(existingExercise).CurrentValues.SetValues(exercises);
                await dbContext.SaveChangesAsync();
                return existingExercise;
            }

            return null;
        }

        public async Task<Exercises?> DeleteAsync(Guid id)
        {
            var existingExercise = await dbContext.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
            if (existingExercise == null)
            {
                return null;
            }

            dbContext.Exercises.Remove(existingExercise);
            await dbContext.SaveChangesAsync();
            return existingExercise;
        }
    }
}
