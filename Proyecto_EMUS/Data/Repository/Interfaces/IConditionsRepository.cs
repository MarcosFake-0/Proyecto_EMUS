using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IConditionsRepository : IRepository<Conditions>
    {
        void Update(Conditions Conditions);
    }
}
