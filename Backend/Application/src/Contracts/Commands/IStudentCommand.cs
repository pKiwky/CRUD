using Application.Dto;

namespace Application.Contracts {

    public interface IStudentCommand {
        Task<KernelControllerResponse<CreateStudentResponse>> CreateStudent(CreateStudentRequest createStudentRequest);
        Task<KernelControllerResponse<KernelResponse>> UpdateStudent(Guid id, UpdateStudentRequest updateStudentRequest);
        Task<KernelControllerResponse<KernelResponse>> DeleteStudent(Guid id);
    }

}