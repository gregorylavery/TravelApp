using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

[Table("USER_LOGINS")]
public partial class UserLogin
{
    [Column("USER_LOGIN_ID")]
    public int UserLoginId { get; set; }

    [Column("USER_EMAIL")]
    public string? UserEmail { get; set; }

    [Column("USER_PASSWORD")] 
    public string? UserPassword { get; set; }
}
