using Proyecto_EMUS.Models;
using System.Linq.Expressions;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient Patient);
        IEnumerable<Patient> GetAllByDoctor(Expression<Func<Patient, bool>> filter, string? includeProperties = null);
    }
}
