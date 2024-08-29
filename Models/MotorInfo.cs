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
        [StringLength(50, ErrorMessage = "Brand can not be longer than 50 characters")]
        public string Brand { get; set; }

        [Required]
        [Column("model")]
        [StringLength(50, ErrorMessage = "Model can not be longer than 50 characters")]
        public string Model { get; set; }

        [Required]
        [Column("displacement")]
        [Range(0.1, 10.0, ErrorMessage = "Displacement must be between 0.1 and 10.0 liters")]
        public float Displacement { get; set; }

        [Required]
        [Column("cylinders")]
        [Range(1, 16, ErrorMessage = "Cylinders must be between 1 and 16")]
        public int Cylinders { get; set; }

        [Required]
        [Column("aspiration")]
        [StringLength(20, ErrorMessage = "Aspiration can not be longer than 20 characters")]
        public string Aspiration { get; set; }

        [Required]
        [Column("horse_power")]
        [Range(0, 2000, ErrorMessage = "HorsePower must be between 0 and 2000")]
        public int HorsePower { get; set; }

        [Required]
        [Column("torque")]
        [Range(0, 2000, ErrorMessage = "Torque must be between 0 and 2000")]
        public int Torque { get; set; }

        [Required]
        [Column("fuel_type")]
        [EnumDataType(typeof(FuelTypeEnum))]
        public FuelTypeEnum FuelType { get; set; }

        [NotMapped]
        public string FuelTypeName => FuelType.ToString();

        [Required]
        [Column("is_turbocharged")]
        public bool IsTurbocharged { get; set; }

        [Required]
        [Column("year")]
        [Range(1886, 2100, ErrorMessage = "Year must be between 1886 and 2100")]
        public int Year { get; set; }
    }

        public enum FuelTypeEnum
    {
        Gasoline = 1,
        Diesel = 2,
        Electric = 3
    }
    
}
