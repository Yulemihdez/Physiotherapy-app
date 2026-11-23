using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class Habits : BaseEntity
{
       public string Name { get; set; } = string.Empty;

    public ICollection<PatientHabit> PatientHabits { get; set; }
        = new List<PatientHabit>();
}
