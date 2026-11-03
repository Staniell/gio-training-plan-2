namespace CourseHub.Core.Domain;

public class CourseModule
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; } = "";
    public int Order { get; set; }
    public int DurationMinutes { get; set; }
}
