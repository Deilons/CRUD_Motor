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
        [MaxLength(50, ErrorMessage = "Brand can not be longer than 50 characters")]
        public string Brand { get; set; }

        [Required]
        [Column("model")]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "Model can not be longer than 45 characters")]
        public string Model { get; set; }

        [Required]
        [Column("displacement")]
        [Range(0.1, 10.0)]
        [MaxLength(10, ErrorMessage = "Displacement can not be longer than 10 characters")]
        public float Displacement { get; set; }

        [Required]
        [Column("cylinders")]
        [Range(1, 16)]
        [MaxLength(2, ErrorMessage = "Cylinders can not be longer than 2 characters")]
        public int Cylinders { get; set; }

        [Required]
        [Column("aspiration")]
        [StringLength(20)]
        [MaxLength(20, ErrorMessage = "Aspiration can not be longer than 20 characters")]
        public string Aspiration { get; set; }

        [Required]
        [Column("horse_power")]
        [Range(0, 2000)]
        [MaxLength(4, ErrorMessage = "HorsePower can not be longer than 4 characters")]
        public int HorsePower { get; set; }

        [Required]
        [Column("torque")]
        [Range(0, 2000)]
        [MaxLength(4, ErrorMessage = "Torque can not be longer than 4 characters")]
        public int Torque { get; set; }

        [Required]
        [Column("fuel_type")]
        [Range(0, 2, ErrorMessage = "FuelType must be between 0 and 2")]
        [MaxLength(10, ErrorMessage = "FuelType can not be longer than 10 characters")]
        public FuelTypeEnum FuelType { get; set; }

        [Required]
        [Column("is_turbocharged")]
        [MaxLength(10, ErrorMessage = "IsTurbocharged can not be longer than 10 characters")]
        public bool IsTurbocharged { get; set; }

        [Required]
        [Column("year")]
        [Range(1886, 2100)]
        [MaxLength(4, ErrorMessage = "Year can not be longer than 4 characters")]
        public int Year { get; set; }

        [NotMapped]
        public string FuelTypeName => FuelType.ToString();
    }

        public enum FuelTypeEnum
    {
        Gasoline = 1,
        Diesel = 2,
        Electric = 3
    }
    
}
