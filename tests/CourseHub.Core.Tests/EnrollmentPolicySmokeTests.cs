using CourseHub.Core.Domain;
using CourseHub.Core.Policies;

namespace CourseHub.Core.Tests;

public class EnrollmentPolicySmokeTests
{
    [Fact]
    public void Instructor_cannot_enroll_in_own_course()
    {
        var course = new Course { Id = 1, InstructorId = "instructor-ana", IsPublished = true, Capacity = 30 };

        var decision = EnrollmentPolicy.CanEnroll(course, "instructor-ana", Array.Empty<Enrollment>(), new DateTime(2026, 11, 3, 2, 0, 0, DateTimeKind.Utc));

        Assert.False(decision.Allowed);
        Assert.Equal("instructor-cannot-enroll", decision.Reason);
    }
}
