namespace WebApplication1.Models.DTO
{
    public class ExercisesDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
