using Application.Dto;

namespace Application.Contracts.Queries {

    public interface IStudentQuery {
        Task<KernelControllerResponse<IEnumerable<GetStudentResponse>>> GetAll();
    }

}