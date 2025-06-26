namespace Cistema.Models.DTO;

public class AddressInfoDTO
{
    public string CEP { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string AddressLine2 { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    
    public int EmployeeId { get; set; }
}