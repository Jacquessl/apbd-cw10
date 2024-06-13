using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(MedicamentId), nameof(PrescriptionId))]
public class PrescriptionMedicament
{
    public int Dose { get; set; }
    [MaxLength(100)] 
    public string Details { get; set; } = string.Empty;
    public int MedicamentId { get; set; }
    public int PrescriptionId { get; set; }
    [ForeignKey(nameof(MedicamentId))] 
    public Medicament Medicament { get; set; } = null!;
    [ForeignKey(nameof(PrescriptionId))] 
    public Prescription Prescription { get; set; } = null!;
}