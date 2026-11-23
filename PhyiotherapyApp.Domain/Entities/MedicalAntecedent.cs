using PhysiotherapyApp.Domain.Entities.Common;
using PhysiotherapyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class MedicalAntecedent : BaseEntity
{

    public TypeAntecedent TypeAntecedent { get; set; }

    public string Notes { get; set; } = string.Empty;

    public Guid MedicalHistoryId { get; set; }

    [ForeignKey(nameof(MedicalHistoryId))]
    public MedicalHistory MedicalHistory { get; set; } = null!;
}


