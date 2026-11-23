using PhysiotherapyApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class SpecialTest: BaseEntity
{
    public string NameOfTests { get; set; } = string.Empty;

    public bool Result { get; set; }

    public string Notes { get; set; }= string.Empty;

    public ICollection<Diagnosis> Diagnoses { get;set; }= new List<Diagnosis>();
}
