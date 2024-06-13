namespace WebApplication1.Models.DTOs;

public class PrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Doctor Doctor { get; set; }
    public List<MedicamentDTO> Medicaments { get; set; }
}