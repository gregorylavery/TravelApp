using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

[Table("TRANSPORTATION_OPTIONS")]
public partial class TransportationOption
{
    public int Id { get; set; }

    public string? Description { get; set; }

    [Column("PROVIDER_NAME")] 
    public string? ProviderName { get; set; }

    [Column("VEHICLE_TYPE")]
    public string? VehicleType { get; set; }

    public decimal? Price { get; set; }

    public string? Duration { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }
}
