using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class Treatment: BaseEntity
{

    public string Description { get; set; } = string.Empty;

    public string Goals { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    
    public Diagnosis? Diagnosis { get; set; }

    public ICollection<Exercises> Exercises { get; set; } = new List<Exercises>();



}