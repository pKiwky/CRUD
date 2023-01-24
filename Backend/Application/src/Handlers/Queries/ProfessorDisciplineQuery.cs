using Application.Contracts.Queries;
using Application.Dto;

namespace Application.Handlers {

    public class ProfessorDisciplineQuery : IProfessorDisciplineQuery {
        public async Task<KernelControllerResponse<IEnumerable<GetProfessorResponse>>> GetAll() {
            throw new NotImplementedException();
        }
    }

}