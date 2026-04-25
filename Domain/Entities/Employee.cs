using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(15)]
    public string? Phone { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Salary { get; set; }

    [StringLength(50)]
    public string? Department { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public bool? IsActive { get; set; }
}
