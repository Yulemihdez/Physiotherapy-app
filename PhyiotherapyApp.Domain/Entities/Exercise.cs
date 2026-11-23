using PhysiotherapyApp.Domain.Entities.Common;
using PhysiotherapyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhysiotherapyApp.Domain.Entities;

public class Exercises: BaseEntity
{
    public TypeOfExersice TypeOfExersicee { get; set; } = TypeOfExersice.fuerza;

    public string Description {  get; set; } = string.Empty;
    public string SetsReps { get; set; } = string.Empty;
    public byte Frequency { get; set; }= 0;
    public string Notes {  get; set; } = string.Empty;

    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();



}
