using Cistema.Enums;

namespace Cistema.Models.DTO;

public class EmployeeReadDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public Nationality Nationality { get; set; }
    public string BirthPlace { get; set; }
    
    public string AddressDescription { get; set; }
    public string TitleName { get; set; }

    public DateTime Admission { get; set; }
    public Contract Contract { get; set; }
    public decimal Salary { get; set; }
    public string CTPS { get; set; }
    public string PIS { get; set; }

    public bool Active { get; set; }

    public DateTime Register { get; set; }
    public string Creator { get; set; }
    public DateTime? LastUpdate { get; set; }
}