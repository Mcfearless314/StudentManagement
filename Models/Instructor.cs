namespace StudentManagement.Models;

public class Instructor
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public required DateTime HireDate { get; set; }
}