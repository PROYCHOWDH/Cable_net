using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Keyless]
[Table("TBL_CUSTOMER", Schema = "dbo")]
public partial class TblCustomer
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("Customer_Name")]
    [StringLength(200)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(20)]
    public string? Contact { get; set; }

    [Column("Create_Date", TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Column(TypeName = "decimal(18, 3)")]
    public decimal? Discount { get; set; }
}
