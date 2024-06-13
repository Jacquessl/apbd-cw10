using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class AddPrescriptionDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = "Lista musi zawierać co najmniej 1 element.")]
    [MaxLength(10, ErrorMessage = "Lista może zawierać maksymalnie 10 elementów.")]
    public List<MedicamentDTO> Medicaments { get; set; }
}