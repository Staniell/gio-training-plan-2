using CourseHub.Core.Domain;

namespace CourseHub.Core.Data;

public static class DbSeeder
{
    private static readonly string[] Topics =
    {
        "C#", "ASP.NET Core", "EF Core", "Docker", "PostgreSQL", "Redis", "React", "TypeScript",
        "Testing", "Security", "Observability", "System Design", "Git", "CI/CD", "Azure", "AWS"
    };

    public static void Seed(CourseHubDbContext db)
    {
        if (db.Courses.Any())
        {
            return;
        }

        var created = new DateTime(2026, 1, 5, 0, 0, 0, DateTimeKind.Utc);
        var courses = new List<Course>();

        for (var i = 1; i <= 200; i++)
        {
            var topic = Topics[(i - 1) % Topics.Length];
            var course = new Course
            {
                Title = $"{topic} Track {i:000}",
                Description = $"Self-paced {topic} course number {i}.",
                InstructorId = i % 2 == 0 ? "instructor-ana" : "instructor-ben",
                IsPublished = i % 10 != 0,
                Capacity = i % 25 == 0 ? 0 : 30,
                EnrollmentClosesAt = i % 7 == 0 ? new DateTime(2026, 12, 31, 16, 0, 0, DateTimeKind.Utc) : null,
                CreatedAt = created.AddDays(i)
            };

            for (var m = 1; m <= 5; m++)
            {
                course.Modules.Add(new CourseModule
                {
                    Title = $"{topic} module {m}",
                    Order = m,
                    DurationMinutes = 20 + (m * 5)
                });
            }

            courses.Add(course);
        }

        db.Courses.AddRange(courses);
        db.SaveChanges();

        var enrolledAt = new DateTime(2026, 3, 2, 1, 0, 0, DateTimeKind.Utc);
        var smallCourse = courses[0];
        for (var l = 1; l <= 29; l++)
        {
            db.Enrollments.Add(new Enrollment
            {
                CourseId = smallCourse.Id,
                LearnerId = $"learner-{l:000}",
                EnrolledAt = enrolledAt.AddMinutes(l),
                Status = EnrollmentStatus.Active
            });
        }

        db.Enrollments.Add(new Enrollment
        {
            CourseId = courses[2].Id,
            LearnerId = "learner-gio",
            EnrolledAt = enrolledAt,
            Status = EnrollmentStatus.Dropped
        });

        db.SaveChanges();
    }
}
