using Application.Dto;

namespace Application.Contracts {

    public interface IProfessorDisciplineCommand {
        Task<KernelControllerResponse<CreateProfessorDisciplineResponse>> CreateProfessorDiscipline(CreateProfessorDisciplineRequest createProfessorDisciplineRequest);
        Task<KernelControllerResponse<KernelResponse>> UpdateProfessorDiscipline(Guid id, UpdateProfessorDisciplineRequest updateProfessorDisciplineRequest);
        Task<KernelControllerResponse<KernelResponse>> DeleteProfessorDiscipline(Guid id);
    }

}