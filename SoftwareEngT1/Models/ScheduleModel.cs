using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftwareEngT1.Models
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
        }
        public static string ConnectionString { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().ToTable("Schedule");
        }
    }

    public class Schedule
    { 
        [Key]
        public int Id { get; set; }
        [DataType("Date")]
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AppointmentType { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Schedule()
        {

        }
    }
}
