using PhysiotherapyApp.Domain.Entities.Common;
using PhysiotherapyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class MedicalHistory: BaseEntity
{

    public string GeneralNotes { get; set; } = string.Empty;


    public Guid PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

    public ICollection<MedicalAntecedent> MedicalAntecedents { get; set; } = new List<MedicalAntecedent>();


}
