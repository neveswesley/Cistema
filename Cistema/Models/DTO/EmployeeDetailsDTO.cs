namespace Cistema.Models.DTO;

public class EmployeeDetailsDTO
{
    public int Id { get; set; }
    public PersonalInfoDTO PersonalInfo { get; set; }
    public AddressInfoDTO AddressInfo { get; set; }
    public ContactInfoDTO ContactInfo { get; set; }
    public TitleInfoDTO TitleInfo { get; set; }
    public ContractInfoDTO ContractInfo { get; set; }
    
}