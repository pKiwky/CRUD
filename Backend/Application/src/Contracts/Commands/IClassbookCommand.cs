using Application.Dto;

namespace Application.Contracts {

    public interface IClassbookCommand {
        Task<KernelControllerResponse<CreateClassbookGradeResponse>> CreateClassbookGrade(CreateClassbookGradeRequest createClassbookGradeRequest);
        Task<KernelControllerResponse<KernelResponse>> UpdateClassbookGrade(Guid id, UpdateClassbookGradeRequest updateClassbookGradeRequest);
        Task<KernelControllerResponse<KernelResponse>> DeleteClassbookGrade(Guid id);
    }

}