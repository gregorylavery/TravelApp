using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

[Table("BOOKING")]
public partial class Booking
{
    [Column("BOOKING_ID")]
    public int BookingId { get; set; }

    [Column("ID")]
    public int? Id { get; set; }

    [Column("PAYMENT_ID")]
    public int? PaymentId { get; set; }

    //TODO: Fix the model to add this which is now present in the table
    //[Column("USER_LOGIN_ID")]
    //public int? UserLoginId { get; set; }
}
