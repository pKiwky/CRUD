using Application.Contracts;
using Application.Dto;

namespace Application.Handlers {

    public class ProfessorDisciplineCommand : IProfessorDisciplineCommand {
        public async Task<KernelControllerResponse<CreateProfessorDisciplineResponse>> CreateProfessorDiscipline(CreateProfessorDisciplineRequest createProfessorDisciplineRequest) {
            throw new NotImplementedException();
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateProfessorDiscipline(Guid id, UpdateProfessorDisciplineRequest updateProfessorDisciplineRequest) {
            throw new NotImplementedException();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteProfessorDiscipline(Guid id) {
            throw new NotImplementedException();
        }
    }

}