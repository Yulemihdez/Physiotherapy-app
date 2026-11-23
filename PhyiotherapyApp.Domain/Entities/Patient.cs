using PhysiotherapyApp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;


namespace PhysiotherapyApp.Domain.Entities;

public class Patient : BaseEntity
{
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public int DateOfBirth { get; set; }

    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; } = "";

    [MaxLength(80)]
    public string Occupation { get; set; } = string.Empty;

    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    public MedicalHistory? MedicalHistory { get; set; }

    public User? User { get; set; }
   

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    
    public ICollection<ReasonForVisit> ReasonsForVisit { get; set; } = new List<ReasonForVisit>();

    public ICollection<PatientHabit> PatientHabits { get; set; }= new List<PatientHabit>();



    //public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
   //public ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
}

