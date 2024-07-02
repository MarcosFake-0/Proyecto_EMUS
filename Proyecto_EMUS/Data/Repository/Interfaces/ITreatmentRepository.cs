using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface ITreatmentRepository : IRepository<Treatment>
    {
        void Update(Treatment treatment);
    }
}
