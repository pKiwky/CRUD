using Application.Dto;

namespace Application.Contracts.Queries {

    public interface IProfessorDisciplineQuery {
        Task<KernelControllerResponse<IEnumerable<GetProfessorResponse>>> GetAll();
    }

}