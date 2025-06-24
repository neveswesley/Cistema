using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Models;

public class Employee
{
    [Key] public int Id { get; set; }
    public string FullName { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Sex { get; set; }
    public string MaritalStatus { get; set; }
    public string Nationality { get; set; }
    public string BirthPlace { get; set; }

    public int? AddressId { get; set; }
    public Address Address { get; set; }
    
    public int? TitleId { get; set; }
    public Title Title { get; set; }
    public int? ContactId { get; set; }
    public Contact Contact { get; set; }

    public DateTime Admission { get; set; }
    public string Contract { get; set; }
    [Precision(18, 2)]
    public decimal Salary { get; set; }
    public string CTPS { get; set; }
    public string PIS { get; set; }
    public bool Active { get; set; }

    public DateTime Register { get; set; }
    public string Creator { get; set; }
    public DateTime? LastUpdate { get; set; }
   
}