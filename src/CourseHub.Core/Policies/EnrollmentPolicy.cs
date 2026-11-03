using CourseHub.Core.Domain;

namespace CourseHub.Core.Policies;

public static class EnrollmentPolicy
{
    public static EnrollmentDecision CanEnroll(
        Course course,
        string learnerId,
        IReadOnlyCollection<Enrollment> existingEnrollments,
        DateTime nowUtc)
    {
        if (course.InstructorId == learnerId)
        {
            return EnrollmentDecision.Deny("instructor-cannot-enroll");
        }

        if (course.EnrollmentClosesAt.HasValue && nowUtc > course.EnrollmentClosesAt.Value)
        {
            return EnrollmentDecision.Deny("enrollment-closed");
        }

        if (existingEnrollments.Any(e => e.LearnerId == learnerId))
        {
            return EnrollmentDecision.Deny("already-enrolled");
        }

        var activeCount = existingEnrollments.Count(e => e.Status == EnrollmentStatus.Active);
        if (activeCount > course.Capacity)
        {
            return EnrollmentDecision.Deny("course-full");
        }

        return EnrollmentDecision.Allow();
    }
}
