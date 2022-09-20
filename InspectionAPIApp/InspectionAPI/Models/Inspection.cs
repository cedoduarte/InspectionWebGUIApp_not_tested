namespace InspectionAPI.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string? Comments { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
        public InspectionType? InspectionType { get; set; } // propiedad de navegación
    }
}
