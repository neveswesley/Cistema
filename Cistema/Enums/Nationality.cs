using System.ComponentModel.DataAnnotations;

namespace Cistema.Enums;

public enum Nationality
{
    [Display(Name = "Brazilian")]
    Brazilian = 1,
    [Display(Name = "Foreign")]
    Foreign  = 2
}