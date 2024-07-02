using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IDoctorSpecialtyRepository : IRepository<DoctorSpecialty>
    {
        void Update(DoctorSpecialty doctorSpecialty);
        IEnumerable<DoctorSpecialty> GetAllByDoctorGMCNumber(int gmcNumber, string? includeProperties = null);

    }
}
