namespace CourseHub.Api.Controllers;

public record SaveCourseRequest(string Title, string Description, bool IsPublished, int Capacity, DateTime? EnrollmentClosesAt);
