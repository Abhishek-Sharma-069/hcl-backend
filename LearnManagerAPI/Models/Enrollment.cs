namespace LearnManagerAPI.Models;

public class Enrollment
{
    public long Id { get; set; }
    public long? StudentId { get; set; }
    public long? CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }

    // Navigation properties
    public User Student { get; set; }
    public Course Course { get; set; }
}
