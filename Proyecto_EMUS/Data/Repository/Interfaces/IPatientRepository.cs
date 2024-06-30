using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient Patient);
    }
}
