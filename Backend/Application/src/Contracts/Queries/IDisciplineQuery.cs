using Application.Dto;

namespace Application.Contracts.Queries {

    public interface IDisciplineQuery {
        Task<KernelControllerResponse<IEnumerable<GetDisciplineResponse>>> GetAll();
    }

}