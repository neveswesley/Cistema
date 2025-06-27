using Cistema.Enums;

namespace Cistema.Models.DTO;

public class ContractInfoDTO
{
    public DateTime Admission { get; set; }
    public decimal Salary { get; set; }
    public string CTPS { get; set; }
    public string PIS { get; set; }
    public bool Active { get; set; }
    public DateTime Register { get; set; }
    public string Creator { get; set; }
    public DateTime? LastUpdate { get; set; }
}