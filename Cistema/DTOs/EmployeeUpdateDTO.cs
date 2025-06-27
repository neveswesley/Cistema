using System.ComponentModel.DataAnnotations;
using Cistema.Enums;

namespace Cistema.Models.DTO;

public class EmployeeUpdateDTO
{
    [Required]
    public int Id { get; set; }

    public string FullName { get; set; }
    public string RG { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public Nationality Nationality { get; set; }
    public string BirthPlace { get; set; }
    
    public int? AddressId { get; set; }
    public int? TitleId { get; set; }

    public DateTime? Admission { get; set; }
    public Contract Contract { get; set; }
    public decimal? Salary { get; set; }
    public string CTPS { get; set; }
    public string PIS { get; set; }
    public bool? Active { get; set; }
}