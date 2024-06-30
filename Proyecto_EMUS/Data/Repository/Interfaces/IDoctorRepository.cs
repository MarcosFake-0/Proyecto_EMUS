using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor Doctor);
    }
}
