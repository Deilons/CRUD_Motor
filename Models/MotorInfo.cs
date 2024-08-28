using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CRUD_Motor.Models;

[Table("motor_info")]
public class MotorInfo
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public float Displacement { get; set; }

    public int Cylinders { get; set; }

    public string Aspiration { get; set; }

    public int HorsePower { get; set; }

    public int Torque { get; set; }

    public enum FuelType { Gasoline, Diesel, Electric}

    public bool IsTurbocharged { get; set; }

    public int Year { get; set; }
}
