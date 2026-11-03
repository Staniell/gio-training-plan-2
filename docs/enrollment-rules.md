# Enrollment rules

Source of truth for `EnrollmentPolicy.CanEnroll`. Each rule returns the reason code shown when it refuses.

| Rule | Behaviour | Reason code |
|---|---|---|
| R1 | Only published courses accept enrollments. | `course-not-published` |
| R2 | A course accepts enrollments while its **active** enrollments are fewer than `Capacity`. `Capacity = 0` means unlimited. | `course-full` |
| R3 | A learner cannot hold two **active** enrollments in the same course. A learner whose earlier enrollment was dropped may enroll again. | `already-enrolled` |
| R4 | If `EnrollmentClosesAt` is set, enrollment is refused at or after that instant (UTC). | `enrollment-closed` |
| R5 | The course instructor cannot enroll in their own course. | `instructor-cannot-enroll` |

When more than one rule refuses, any one matching reason is acceptable.

Examples:

- Capacity 30 with 29 active enrollments: the 30th learner is accepted, the 31st is refused.
- Capacity 0 with 500 active enrollments: accepted.
- `EnrollmentClosesAt` = 2026-12-31 16:00:00 UTC: accepted at 15:59:59, refused at 16:00:00.
