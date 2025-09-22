namespace StudentManagement.Models;

public class Course
{
    public int CourseId { get; set; }
    public required string Title { get; set; }
    public double Credits { get; set; }
    public int InstructorId { get; set; }
}