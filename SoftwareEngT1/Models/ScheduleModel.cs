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
        [Display(Name="Appointment Date:")]
        public DateTime AppointmentDate { get; set; }
        [DataType("Time")]
        [Display(Name = "Appointment Time:")]
        public DateTime AppointmentTime { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Appointment Type:")]
        public string AppointmentType { get; set; }
        [DataType("PhoneNumber")]
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }
        [DataType("EmailAddress")]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        public Schedule()
        {

        }
    }
}
