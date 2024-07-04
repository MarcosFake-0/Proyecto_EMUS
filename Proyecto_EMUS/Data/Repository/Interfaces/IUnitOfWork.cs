namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IConditionsRepository Conditions { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        ISpecialtyRepository Specialty { get; }
        ITreatmentRepository Treatment { get; }
        IDoctorSpecialtyRepository DoctorSpecialty { get; }
        IClinicalHistoryNoteRepository ClinicalHistoryNote { get; }
        ILaboratoryExamRepository LaboratoryExam { get; }
        IMedicationRepository Medication { get; }
        IPatientTreatmentRepository PatientTreatment { get; }
        IPatientMedicationRepository PatientMedication { get; }
        IPatientConditionRepository PatientCondition { get; }
        IPatientLaboratoryExamRepository PatientLaboratoryExam { get; }
        void Save();
    }
}
