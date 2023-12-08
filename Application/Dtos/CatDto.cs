namespace Application.Dtos
{
    public class CatDto
    {
        public required string Name { get; set; } = string.Empty;
        public required bool LikesToPlay { get; set; }
        public string? Breed { get; set; }
        public int? Weight { get; set; }
    }
}
