using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IPatientConditionRepository : IRepository<PatientCondition>
    {
        void Update(PatientCondition patientCondition);
    }
}
