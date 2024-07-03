using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IPatientTreatmentRepository: IRepository<PatientTreatment>
    {
        void Update(PatientTreatment patientTreatment);
    }
}
