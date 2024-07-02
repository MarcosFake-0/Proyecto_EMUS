﻿namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IConditionsRepository Conditions { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        ISpecialtyRepository Specialty { get; }
        ITreatmentRepository Treatment { get; }
        IDoctorSpecialtyRepository DoctorSpecialty { get; }
        IDrugRepository Drug { get; }
        IClinicalHistoryRepository ClinicalHistory { get; }
        IClinicalHistoryNoteRepository ClinicalHistoryNote { get; }
        ILaboratoryExamRepository LaboratoryExam { get; }

        void Save();
    }
}
