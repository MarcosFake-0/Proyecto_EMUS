using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IClinicalHistoryRepository : IRepository<ClinicalHistory>
    {
        void Update(ClinicalHistory clinicalHistory);
    }
}
