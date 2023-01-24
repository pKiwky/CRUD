using Application.Dto;

namespace Application.Contracts {

    public interface IDisciplineCommand {
        Task<KernelControllerResponse<CreateDisciplineResponse>> CreateDiscipline(CreateDisciplineRequest createDisciplineRequest);
        Task<KernelControllerResponse<KernelResponse>> UpdateDiscipline(Guid id, UpdateDisciplineRequest updateDisciplineRequest);
        Task<KernelControllerResponse<KernelResponse>> DeleteDiscipline(Guid id);
    }

}