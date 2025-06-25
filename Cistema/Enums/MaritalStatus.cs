using System.ComponentModel.DataAnnotations;

namespace Cistema.Enums;
public enum MaritalStatus
{
    [Display(Name = "Single")]
    Single = 1,
    [Display(Name = "Married")]
    Married = 2,
    [Display(Name = "Separated")]
    Separated = 3,
    [Display(Name = "Divorced")]
    Divorced = 4,
    [Display(Name = "Widowed")]
    Widowed = 5,
    [Display(Name = "Common-law Union")]
    CommonLawUnion  = 6
}

