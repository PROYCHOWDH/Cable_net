using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

[Table("TBL_Payment", Schema = "dbo")]
public partial class TblPayment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Customer_Id")]
    public int? CustomerId { get; set; }

    [Column("Debit_Amount", TypeName = "decimal(18, 2)")]
    public decimal? DebitAmount { get; set; }

    [Column("Credit_Amount", TypeName = "decimal(18, 2)")]
    public decimal? CreditAmount { get; set; }

    [Column("Is_Discount")]
    public int? IsDiscount { get; set; }

    [Column("Discount_amount", TypeName = "decimal(18, 2)")]
    public decimal? DiscountAmount { get; set; }

    [Column("After_Discount", TypeName = "decimal(18, 2)")]
    public decimal? AfterDiscount { get; set; }

    [Column("Profit_Amount", TypeName = "decimal(18, 2)")]
    public decimal? ProfitAmount { get; set; }

    [Column("Transactin_Date")]
    public DateOnly? TransactinDate { get; set; }
}
