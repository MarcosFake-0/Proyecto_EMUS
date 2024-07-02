using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IMedicationRepository : IRepository<Medication>
    {
        void Update(Medication medication);
    }
}
