# CourseHub API

Base URL when running locally: `http://localhost:5090`.

The caller is identified by the `X-User-Id` request header.

| Method | Path | Purpose | Success |
|---|---|---|---|
| GET | `/api/courses` | List all courses with module count, total minutes and active enrollments | 200 |
| GET | `/api/courses/{id}` | Course detail with modules | 200, 404 |
| POST | `/api/courses` | Create a course; the caller becomes the instructor | 201 |
| PUT | `/api/courses/{id}` | Update a course | 204, 404 |
| POST | `/api/courses/{id}/enrollments` | Enroll the caller | 201, 404, 409 |
| DELETE | `/api/courses/{id}/enrollments/me` | Drop the caller's active enrollment | 204, 404 |
| GET | `/api/me/enrollments` | The caller's enrollments | 200 |

Error bodies: 404 `{ "error": "..." }`, 409 `{ "message": "...", "code": "<reason code>" }`.

Seed data: 200 courses (5 modules each), instructors `instructor-ana` and `instructor-ben`. Course 1 has 29 active enrollments and capacity 30. Every 10th course is unpublished. Every 25th course has capacity 0. Every 7th course closes enrollment at 2026-12-31 16:00 UTC. `learner-gio` has a dropped enrollment in course 3.
