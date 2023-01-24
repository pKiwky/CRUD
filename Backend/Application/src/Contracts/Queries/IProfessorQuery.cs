using Application.Dto;

namespace Application.Contracts.Queries {

    public interface IProfessorQuery {
        Task<KernelControllerResponse<IEnumerable<GetProfessorResponse>>> GetAll();
    }

}