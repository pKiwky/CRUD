using Application.Contracts.Queries;
using Application.Dto;

namespace Application.Handlers {

    public class ProfessorQuery : IProfessorQuery {
        public async Task<KernelControllerResponse<IEnumerable<GetProfessorResponse>>> GetAll() {
            throw new NotImplementedException();
        }
    }

}