using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor()
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "dsadas"
            },
            new Doctor()
            {
                Id = 2,
                FirstName = "adada",
                LastName = "dsadsad",
                Email = "Dsadsada"
            }
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament()
            {
                Id = 1,
                Name = "Lek",
                Description = "Dziala",
                Type = "dsadasdas"
            },
            new Medicament()
            {
                Id = 2,
                Name = "Lek2",
                Description = "Tez działa",
                Type = "dasdasadfafa"
            }
        });
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient()
            {
                Id = 1,
                FirstName = "Janek",
                LastName = "Niekowalski",
                Birthdate = DateTime.Parse("2000-01-01")
            },
            new Patient()
            {
                Id = 2,
                FirstName = "Ja2nek",
                LastName = "Nieko2walski",
                Birthdate = DateTime.Parse("2001-01-01")
            }
        });
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription()
            {
                Id = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Parse("2024-07-07"),
                DoctorId = 1,
                PatientId = 1,
            },
            new Prescription()
            {
                Id = 2,
                Date = DateTime.Parse("2024-06-06"),
                DueDate = DateTime.Parse("2024-07-07"),
                DoctorId = 1,
                PatientId = 2,
            }
        });
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament()
            {
                Dose = 100,
                Details = "Brac",
                MedicamentId = 1,
                PrescriptionId = 1,
            },
            new PrescriptionMedicament()
            {
                Dose = 50,
                Details = "Brac",
                MedicamentId = 2,
                PrescriptionId = 1,
            }
        });
    }
}