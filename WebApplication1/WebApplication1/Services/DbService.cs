using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }
    public async Task<bool> DoestPatientExist(int patientId)
    {
        return await _context.Patients.AnyAsync(e => e.Id == patientId);
    }

    public async Task<bool> DoesMedicamentExist(int medicamentId)
    {
        return await _context.Medicaments.AnyAsync(e => e.Id == medicamentId);
    }

    public async Task AddNewPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrescrption(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<Patient> GetPatientData(int id)
    {
        return await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}