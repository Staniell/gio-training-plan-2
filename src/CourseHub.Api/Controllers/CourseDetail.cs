namespace CourseHub.Api.Controllers;

public record CourseDetail(int Id, string Title, string Description, string InstructorId, bool IsPublished, int Capacity, DateTime? EnrollmentClosesAt, IReadOnlyList<ModuleItem> Modules);

public record ModuleItem(int Id, string Title, int Order, int DurationMinutes);
