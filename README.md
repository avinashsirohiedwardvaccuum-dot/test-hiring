# C# Coding Test — Task List Web API

A small ASP.NET Core Web API starter project with the models, endpoints, and
tests stubbed out. Your job is to fill in the `TODO`s so the API behaves as
described below, then push your completed solution to a Git repository.

**Time allowed:** ~60–90 minutes
**Total marks:** 60

## Problem Statement

Complete a minimal Web API for managing a simple task list ("to-do" app).

### 1. Model (5 marks) — `TaskListApi/Models/TaskItem.cs`

Finish the `TaskItem` model with:

| Property     | Type       | Rules                                   |
|--------------|------------|------------------------------------------|
| `Id`         | `int`      | Primary key (already provided)          |
| `Title`      | `string`   | Required, max length 100                |
| `IsComplete` | `bool`     | Defaults to `false`                     |
| `CreatedAt`  | `DateTime` | Defaults to `DateTime.UtcNow` on create  |

Also finish `CreateTaskRequest` and `UpdateTaskRequest` in
`Models/TaskDtos.cs` with the matching validation attributes.

### 2. Endpoints (15 marks) — `TaskListApi/Program.cs`

Implement the five endpoints already stubbed out with
`throw new NotImplementedException(...)`, backed by the `TaskDbContext`
(EF Core InMemory provider — already wired up in `Program.cs`):

| Verb   | Route              | Behavior                                                          |
|--------|--------------------|--------------------------------------------------------------------|
| GET    | `/api/tasks`       | Return all tasks, `200 OK`                                        |
| GET    | `/api/tasks/{id}`  | Return one task, `200 OK`; `404 Not Found` if it doesn't exist    |
| POST   | `/api/tasks`       | Create a task; `400 Bad Request` if invalid; `201 Created` + `Location` header on success |
| PUT    | `/api/tasks/{id}`  | Update Title/IsComplete; `404` if missing; `400` if invalid       |
| DELETE | `/api/tasks/{id}`  | Delete the task; `204 No Content`; `404` if it doesn't exist      |

### 3. Validation & Error Handling (5 marks)

`POST`/`PUT` must return `400 Bad Request` with a clear message when
`Title` is missing or longer than 100 characters.

### 4. Testing (5 marks) — `TaskListApi.Tests/TaskEndpointsTests.cs`

Finish `GetTask_ReturnsNotFound_WhenIdDoesNotExist` so it actually
exercises your implementation, and add at least one more test of your
choice (bonus).

### 5. Bonus (not required for full marks)

- Add middleware in `Program.cs` so unhandled exceptions return a clean
  JSON error instead of a raw stack trace.
- Add pagination or filtering (e.g. `?isComplete=true`) to `GET /api/tasks`.

## Evaluation Rubric (interviewer use)

| Area                              | Marks | Notes                                              |
|-----------------------------------|-------|-----------------------------------------------------|
| Model & DTOs                      | 5     | Correct types, validation attributes                |
| Endpoints                         | 15    | Correct HTTP verbs, status codes, routing            |
| Validation & error handling       | 5     | 400 on invalid input, clear messages                 |
| Testing                           | 5     | Test compiles and correctly asserts                  |
| Conceptual understanding (verbal) | 30    | Ask the candidate to explain DI, EF Core, middleware order, etc. during review |
| **Total**                         | **60**|                                                       |

## Getting Started

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
# restore & build
dotnet build

# run the API (default: http://localhost:5080)
dotnet run --project TaskListApi

# run the tests
dotnet test
```

### Project Structure

```
.
├── TaskListApi.sln
├── TaskListApi/                  # the Web API
│   ├── Program.cs                # endpoints — TODOs live here
│   ├── Models/
│   │   ├── TaskItem.cs           # TODO: finish the model
│   │   └── TaskDtos.cs           # TODO: finish the DTOs
│   ├── Data/
│   │   └── TaskDbContext.cs      # EF Core InMemory context (done)
│   └── appsettings.json
└── TaskListApi.Tests/            # xUnit test project
    └── TaskEndpointsTests.cs     # TODO: finish the test
```

## Submitting

1. Complete the TODOs above.
2. Commit your work in a few meaningful commits (not one giant commit).
3. Push to a Git repository (GitHub, GitLab, etc.) and share the link,
   or zip the repo and send it back — whichever your reviewer asked for.

```bash
git init
git add .
git commit -m "Initial scaffold"
# ... make your changes, committing as you go ...
git remote add origin <your-repo-url>
git push -u origin main
```
