using Application.Dto;

namespace Application.Contracts.Queries {

    public interface IProfessorQuery {
        Task<KernelControllerResponse<IEnumerable<GetProfessorResponse>>> GetAll();
        Task<KernelControllerResponse<IEnumerable<GetProfessorDisciplineResponse>>> GetAllProfessorDiscipline(Guid id);
    }

}