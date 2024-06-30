using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        void Update(Specialty Specialty);
    }
  
}
