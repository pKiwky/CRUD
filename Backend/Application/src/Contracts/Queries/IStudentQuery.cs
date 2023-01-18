using Application.Dto;
using Application.DTO.Student;

namespace Application.Contracts.Queries {

    public interface IStudentQuery {
        Task<KernelControllerResponse<IEnumerable<GetStudentResponse>>> GetAll();
    }

}