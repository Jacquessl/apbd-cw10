using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Doctor
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)] 
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}