namespace TramiteGoreu.Dto.Response
{
    public  class MenuResponseDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = default!;
        public string IconName { get; set; } = default!;
        public string Route { get; set; } = default!;
        public int IdAplication { get; set; }
        public int? ParentMenuId { get; set; }
    }
}
