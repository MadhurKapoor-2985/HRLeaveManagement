using HRLeaveSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> modelBuilder)
        {
            modelBuilder.HasData(
                new LeaveType()
                {
                    Id = 1,
                    Name = "Vacation",
                    DefaultDays = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                });

        }
    }
}
