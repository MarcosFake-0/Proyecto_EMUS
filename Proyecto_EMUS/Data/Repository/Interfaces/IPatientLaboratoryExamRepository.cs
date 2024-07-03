using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IPatientLaboratoryExamRepository : IRepository<LaboratoryExam>
    {
        void Update(PatientLaboratoryExam patientLaboratoryExam);
    }
}
