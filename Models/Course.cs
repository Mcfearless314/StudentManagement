namespace StudentManagement.Models;

public class Course
{
    public int CourseId { get; set; }
    public required string Title { get; set; }
    public int Credits { get; set; }
}