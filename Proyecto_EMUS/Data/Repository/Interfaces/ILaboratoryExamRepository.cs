using Microsoft.EntityFrameworkCore.Query.Internal;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface ILaboratoryExamRepository : IRepository<LaboratoryExam>
    {
        void Update(LaboratoryExam laboratoryExam);
    }
}
