using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IPatientMedicationRepository: IRepository<PatientMedication>
    {
        void Update(PatientMedication patientMedication);
    }
}
