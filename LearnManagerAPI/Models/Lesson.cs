namespace LearnManagerAPI.Models;

public class Lesson
{
    public long Id { get; set; }
    public long? CourseId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int OrderIndex { get; set; }

    // Navigation properties
    public Course Course { get; set; }
}
