using Microsoft.EntityFrameworkCore;
using PhysiotherapyApp.Domain.Entities;
using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysiotherapyApp.Infrastructure.Data;

public class PhysioDbContext : DbContext
{
    public PhysioDbContext(
        DbContextOptions<PhysioDbContext> options)
        : base(options)
    {
    }
 
    // Entidades principales
    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Appointment> Appointments
        => Set<Appointment>();

    public DbSet<Diagnosis> Diagnoses
        => Set<Diagnosis>();

    public DbSet<ReasonForVisit> ReasonsForVisit
        => Set<ReasonForVisit>();

    public DbSet<MedicalHistory> MedicalHistories
        => Set<MedicalHistory>();

    public DbSet<Treatment> Treatments
        => Set<Treatment>();
    public DbSet<PatientHabit> PatientHabits
    => Set<PatientHabit>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


    //Change tracking-guarda cambios automatico de bas entity 
    public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

