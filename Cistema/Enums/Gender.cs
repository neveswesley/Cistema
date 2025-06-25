﻿using System.ComponentModel.DataAnnotations;

namespace Cistema.Enums;

public enum Gender
{
    [Display(Name = "Male")]
    Male = 1,
    [Display(Name = "Female")]
    Female = 2,
    [Display(Name = "Other")]
    Other = 3
}