using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IDrugRepository :IRepository<Drug>
    {
        void Update(Drug drug);
    }
}
