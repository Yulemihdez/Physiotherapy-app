using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class PatientHabit: BaseEntity
{

    public Guid PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

    public Guid HabitId { get; set; }

    [ForeignKey(nameof(HabitId))]
    public Habits Habit { get; set; } = null!;

    [MaxLength(100)]
    public string FrequencyWeekly { get; set; } = string.Empty;
}


