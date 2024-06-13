using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Patient
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}