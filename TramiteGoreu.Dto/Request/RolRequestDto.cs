namespace Goreu.Tramite.Dto.Request
{
    public class RolRequestDto
    {
        public string Name { get; set; } = default!;
        public bool CanCreate { get; set; } = true;
        public bool CanDelete { get; set; } = true;
        public bool CanUpdate { get; set; } = true;
        public bool CanSearch { get; set; } = true;
        public string NormalizedName { get; set; } = default!;

    }
}
