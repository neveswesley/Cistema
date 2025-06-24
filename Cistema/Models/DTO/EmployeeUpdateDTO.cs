using System.ComponentModel.DataAnnotations;

namespace Cistema.Models.DTO;

public class EmployeeUpdateDTO
{
    [Required]
    public int Id { get; set; }

    public string FullName { get; set; }
    public string RG { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; }
    public string MaritalStatus { get; set; }
    public string Nationality { get; set; }
    public string BirthPlace { get; set; }
    
    public int? AddressId { get; set; }
    public int? TitleId { get; set; }

    public DateTime? Admission { get; set; }
    public string Contract { get; set; }
    public decimal? Salary { get; set; }
    public string CTPS { get; set; }
    public string PIS { get; set; }
    public bool? Active { get; set; }
}