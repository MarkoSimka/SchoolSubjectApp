namespace School_Subjects_Information_system.Models
{
    public class Subject : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int WeeklyClasses { get; set; }
        public List<string>? LiteratureUsed { get; set; }
        public AdditionalProperties? AdditionalProperties { get; set; }
    }

    public class AdditionalProperties
    {
        public string? Teacher { get; set; }
        public string? Room { get; set; }
        public string? GradeLevel { get; set; }
    }
}