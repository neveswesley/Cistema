using Microsoft.EntityFrameworkCore;

namespace Cistema.Models;

public class Title
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Description { get; set; }

    public List<Employee> Employees { get; set; }
}