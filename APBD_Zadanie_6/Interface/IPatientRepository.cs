public interface IPatientRepository
{
    Task<Patient> GetPatientAsync(int id);
    Task AddPatientAsync(Patient patient);
    Task<Patient> GetPatientDetailsAsync(int id);
}