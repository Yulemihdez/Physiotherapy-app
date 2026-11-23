using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class User: BaseEntity
{
    public string user { get; set; } = string.Empty;

    public string password { get; set; }= string.Empty;

    public Guid PatientId { get; set; }
    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;
}
