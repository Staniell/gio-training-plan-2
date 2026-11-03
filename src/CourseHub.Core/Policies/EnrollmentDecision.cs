namespace CourseHub.Core.Policies;

public sealed record EnrollmentDecision(bool Allowed, string? Reason)
{
    public static EnrollmentDecision Allow() => new(true, null);

    public static EnrollmentDecision Deny(string reason) => new(false, reason);
}
