namespace StudentManagement.Models;

public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Budget { get; set; }
    public required DateOnly StartDate { get; set; }
    public Instructor DepartmentHead { get; set; }
    public int DepartmentHeadId { get; set; }
}
