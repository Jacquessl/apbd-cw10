using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Medicament
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    [MaxLength(100)]
    public string Type { get; set; }
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } =
        new HashSet<PrescriptionMedicament>();
}