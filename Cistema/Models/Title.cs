using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Models;

public class Title
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Description { get; set; }

    public ICollection<Employee> Employees { get; set; }
}