namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IConditionsRepository Conditions { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        ISpecialtyRepository Specialty { get; }
        
        void Save();
    }
}
