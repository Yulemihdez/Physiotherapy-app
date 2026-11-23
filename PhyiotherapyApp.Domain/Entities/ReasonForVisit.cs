using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class ReasonForVisit: BaseEntity
{
    public string Title {  get; set; }=string.Empty;

    public string Description { get; set; } = string.Empty;

    public string MecanismoLesion { get; set; } = string.Empty;

    public DateOnly FechaIncidente { get; set; }

    //TIPO DE RELACION 1:1 -PROPIEDAD DE NAVEGACION OPCIONAL
    public Diagnosis? Diagnosis { get; set; }

    //TIPO DE RELACION= 1:N -FOREIGN KEY
    public Guid PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

}
