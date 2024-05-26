public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Patient> GetPatientAsync(int id)
    {
        return await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Prescription_Medicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == id);
    }

    public async Task AddPatientAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<Patient> GetPatientDetailsAsync(int id)
    {
        return await _context.Patients
            .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.Prescription_Medicaments)
                    .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.Doctor)
            .FirstOrDefaultAsync(p => p.IdPatient == id);
    }
}