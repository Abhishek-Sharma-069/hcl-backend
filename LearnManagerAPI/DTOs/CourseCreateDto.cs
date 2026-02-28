namespace LearnManagerAPI.DTOs;

public class CourseCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long? InstructorId { get; set; }
}
