using Application.Dto;
using Application.DTO.Student;

namespace Application.Contracts {

    public interface IStudentCommand {
        Task<KernelControllerResponse<CreateStudentResponse>> CreateStudent(CreateStudentRequest createStudentRequest);
        Task<KernelControllerResponse<KernelDeleteResponse>> DeleteStudent(Guid id);
    }

}