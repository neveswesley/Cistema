using System.ComponentModel.DataAnnotations;

namespace Cistema.Enums;

public enum Contract
{
    [Display(Name = "CLT")]
    CLT = 1,
    [Display(Name = "PJ")]
    PJ = 2,
    [Display(Name = "Temporary")]
    Temporary = 3,
    [Display(Name = "Internship")]
    Internship = 4
    
}