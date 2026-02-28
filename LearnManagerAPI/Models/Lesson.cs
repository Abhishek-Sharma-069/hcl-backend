namespace LearnManagerAPI.Models;

public class Lesson
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int OrderIndex { get; set; }

    // navigation
    public Course Course { get; set; }
}
