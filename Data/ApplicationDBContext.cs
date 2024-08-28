using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Motor.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<Models.MotorInfo> MotorInfos { get; set; }

    public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
}
