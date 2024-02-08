using WebApplication1.Models.Domain;


namespace WebApplication1.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        Task<Exercises> CreateAsync(Exercises exercises);

        Task<IEnumerable<Exercises>> GetAllAsync();

        Task<Exercises>? GetById(Guid id);

        Task<Exercises>? UpdateAsync(Exercises exercises);

        Task<Exercises>? DeleteAsync(Guid id);
    }
}
