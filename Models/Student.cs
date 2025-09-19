using System;

namespace StudentManagement.Models;

public class Student
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public string MiddleName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public required DateTime EnrollmentDate { get; set; }
}