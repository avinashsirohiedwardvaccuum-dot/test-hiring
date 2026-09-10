using System.ComponentModel.DataAnnotations;

namespace TaskListApi.Models;

public class CreateTaskRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
}

public class UpdateTaskRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    public bool IsComplete { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace TaskListApi.Models;

public class CreateTaskRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
}

public class UpdateTaskRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    public bool IsComplete { get; set; }
}
