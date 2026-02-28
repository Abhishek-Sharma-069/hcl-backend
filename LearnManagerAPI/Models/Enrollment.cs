namespace LearnManagerAPI.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }

    // navigation
    public User Student { get; set; }
    public Course Course { get; set; }
}
