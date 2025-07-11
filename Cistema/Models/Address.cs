﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cistema.Models;

public class Address
{
    [Key] public int Id { get; set; }
    public string CEP { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string AddressLine2 { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}