namespace CourseHub.Core.Domain;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string InstructorId { get; set; } = "";
    public bool IsPublished { get; set; }
    public int Capacity { get; set; }
    public DateTime? EnrollmentClosesAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<CourseModule> Modules { get; set; } = new();
    public List<Enrollment> Enrollments { get; set; } = new();
}
