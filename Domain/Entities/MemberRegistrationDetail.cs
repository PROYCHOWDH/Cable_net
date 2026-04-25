using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class MemberRegistrationDetail
{
    public int MemberId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailId { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? UserType { get; set; }

    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? UpdatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? IsActive { get; set; }
}
