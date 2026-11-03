namespace CourseHub.Core.Domain;

public class Enrollment
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public string LearnerId { get; set; } = "";
    public DateTime EnrolledAt { get; set; }
    public EnrollmentStatus Status { get; set; }
}
