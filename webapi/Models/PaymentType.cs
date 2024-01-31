using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

[Table("PAYMENT_TYPE")]
public partial class PaymentType
{
    [Column("PAYMENT_TYPE_ID")]
    public int PaymentTypeId { get; set; }

    [Column("PAYMENT_TYPE")]
    public string? PaymentType1 { get; set; }

    public string? Description { get; set; }
}
