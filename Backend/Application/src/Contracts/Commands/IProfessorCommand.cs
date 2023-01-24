using Application.Dto;

namespace Application.Contracts {

    public interface IProfessorCommand {
        Task<KernelControllerResponse<CreateProfessorResponse>> CreateProfessor(CreateProfessorRequest createProfessorRequest);
        Task<KernelControllerResponse<KernelResponse>> UpdateProfessor(Guid id, UpdateProfessorRequest updateProfessorRequest);
        Task<KernelControllerResponse<KernelResponse>> DeleteProfessor(Guid id);
    }
}