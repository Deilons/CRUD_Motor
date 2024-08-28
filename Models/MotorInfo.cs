using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Motor.Models
{
    [Table("motor_info")]
    public class MotorInfo
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("brand")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [Column("model")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Column("displacement")]
        [Range(0.1, 10.0)]
        public float Displacement { get; set; }

        [Required]
        [Column("cylinders")]
        [Range(1, 16)]
        public int Cylinders { get; set; }

        [Required]
        [Column("aspiration")]
        [StringLength(20)]
        public string Aspiration { get; set; }

        [Required]
        [Column("horse_power")]
        [Range(0, 2000)]
        public int HorsePower { get; set; }

        [Required]
        [Column("torque")]
        [Range(0, 2000)]
        public int Torque { get; set; }

        [Required]
        [Column("fuel_type")]
        public FuelTypeEnum FuelType { get; set; }

        [Required]
        [Column("is_turbocharged")]
        public bool IsTurbocharged { get; set; }

        [Required]
        [Column("year")]
        [Range(1886, 2100)]  // Considerando que el primer automóvil se fabricó en 1886
        public int Year { get; set; }
    }

    public enum FuelTypeEnum
    {
        Gasoline,
        Diesel,
        Electric
    }
}
