using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class Diagnosis: BaseEntity
{
   
    public string Title { get; set; } = string.Empty;

    public string Observations { get; set; }= string.Empty;

   
    public Guid ReasonForVisitId { get; set; }
    [ForeignKey(nameof(ReasonForVisitId))]
    public ReasonForVisit ReasonForVisit { get; set; } = null!;


    //PREGUNTAR ERICK 
    public Guid TreatmentId { get; set; }
    [ForeignKey(nameof(TreatmentId))]
    public Treatment Treatment { get; set; } = null!;


    public ICollection<Appointment> Appointments{ get; set; } = new List<Appointment>();

    public ICollection<SpecialTest> SpecialTests { get; set; } = new List<SpecialTest>();


}
