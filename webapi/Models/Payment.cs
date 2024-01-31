using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

[Table("PAYMENT")]
public partial class Payment
{
    [Column("PAYMENT_ID")]
    public int PaymentId { get; set; }

    [Column("ID")]
    public int? Id { get; set; }

    public decimal? Price { get; set; }

    [Column("PAYMENT_TYPE_ID")]
    public string? PaymentTypeId { get; set; }
}
