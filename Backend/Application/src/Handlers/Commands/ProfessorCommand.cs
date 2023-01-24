using Application.Contracts;
using Application.Dto;

namespace Application.Handlers {

    public class ProfessorCommand : IProfessorCommand {
        public async Task<KernelControllerResponse<CreateProfessorResponse>> CreateProfessor(CreateProfessorRequest createProfessorRequest) {
            throw new NotImplementedException();
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateProfessor(Guid id, UpdateProfessorRequest updateProfessorRequest) {
            throw new NotImplementedException();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteProfessor(Guid id) {
            throw new NotImplementedException();
        }
    }

}