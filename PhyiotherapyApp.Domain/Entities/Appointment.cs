using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhysiotherapyApp.Domain.Entities.Common;
using PhysiotherapyApp.Domain.Enums;

namespace PhysiotherapyApp.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime ScheduledAt { get; set; }

    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.Pending;

    public int SessionNumber { get; set; }

    public Guid PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;


    public Guid? DiagnosisId { get; set; }
    [ForeignKey(nameof(DiagnosisId))]
    public Diagnosis? Diagnosis { get; set; } = null!;
}




