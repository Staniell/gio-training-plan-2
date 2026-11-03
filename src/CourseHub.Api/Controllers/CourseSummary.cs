namespace CourseHub.Api.Controllers;

public record CourseSummary(int Id, string Title, string InstructorId, bool IsPublished, int ModuleCount, int TotalMinutes, int ActiveEnrollments);
