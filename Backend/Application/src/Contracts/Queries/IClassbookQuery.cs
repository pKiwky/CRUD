using Application.Dto;

namespace Application.Contracts.Queries {

    public interface IClassbookQuery {
        Task<KernelControllerResponse<IEnumerable<GetClassbookGradeResponse>>> GetStudentGrades(Guid id);
    }

}