using Cistema.Enums;

namespace Cistema.Models.DTO;

public class PersonalInfoDTO
{
    public string FullName { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public Nationality Nationality { get; set; }
    public string BirthPlace { get; set; }
}