﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FWF.Dal.Models;

[PrimaryKey("Airline", "SourceAirport", "DestinationAirport", "CodeShare", "Stops")]
[Table("route")]
public partial class Route
{
    [Key]
    [Column("airline")]
    [StringLength(50)]
    public string Airline { get; set; }

    [Key]
    [Column("sourceAirport")]
    [StringLength(50)]
    public string SourceAirport { get; set; }

    [Key]
    [Column("destinationAirport")]
    [StringLength(50)]
    public string DestinationAirport { get; set; }

    [Key]
    [Column("codeShare")]
    [StringLength(50)]
    public string CodeShare { get; set; }

    [Key]
    [Column("stops")]
    public int Stops { get; set; }

    [Column("equipment")]
    [StringLength(50)]
    public string Equipment { get; set; }

    [Column("sourceName")]
    [StringLength(50)]
    public string SourceName { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}