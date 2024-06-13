using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPrescription([FromBody]AddPrescriptionDTO addPrescriptionDto)
    {
        if (addPrescriptionDto.Date >= addPrescriptionDto.DueDate)
        {
            return BadRequest("Due date nie może być przed date");
        }
        foreach(var medicament in addPrescriptionDto.Medicaments)
        {
            if (!await _dbService.DoesMedicamentExist(medicament.Id))
            {
                return NotFound("Jedno z lekarstw nie istnieje");
            }
        }
        if (!await _dbService.DoestPatientExist(addPrescriptionDto.IdPatient))
        {
            await _dbService.AddNewPatient(new Patient()
            {
                FirstName = addPrescriptionDto.FirstName,
                LastName = addPrescriptionDto.LastName,
                Birthdate = addPrescriptionDto.Birthdate
            });
        }

        await _dbService.AddPrescrption(new Prescription()
        {
            Date = addPrescriptionDto.Date,
            DueDate = addPrescriptionDto.DueDate,
            DoctorId = addPrescriptionDto.IdDoctor,
            PatientId = addPrescriptionDto.IdPatient
        });
        return Created();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientsData(int id)
    {
        if (!await _dbService.DoestPatientExist(id))
        {
            return NotFound("Pacjent nie istnieje");
        }
        var patient = await _dbService.GetPatientData(id);
        if (patient == null)
        {
            return NotFound("Pacjent nie istnieje");
        }

        var response = new PatientDTO()
        {
            IdPatient = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(p => p.DueDate)
                .Select(p => new PrescriptionDTO()
                {
                    IdPrescription = p.Id,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new Doctor()
                    {
                        Id = p.Doctor.Id,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                    },
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDTO()
                    {
                        Id = pm.Medicament.Id,
                        Description = pm.Medicament.Description,
                        Dose = pm.Dose
                    }).ToList()
                }).ToList()
        };
        return Ok(response);
    }
}