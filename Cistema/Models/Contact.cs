namespace Cistema.Models;

public class Contact
{
    public int Id { get; set; }
    public string? Phone { get; set; }
    public string Mobile { get; set; }
    public string? Email { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}