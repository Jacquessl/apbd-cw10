using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<bool> DoestPatientExist(int patientId);
    Task<bool> DoesMedicamentExist(int medicamentId);
    Task AddNewPatient(Patient patient);
    Task AddPrescrption(Prescription prescription);
    Task<Patient> GetPatientData(int id);
}