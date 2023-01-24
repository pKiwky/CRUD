using Application.Contracts.Queries;
using Application.Dto;

namespace Application.Handlers {

    public class ClassbookQuery : IClassbookQuery {
        public async Task<KernelControllerResponse<IEnumerable<GetClassbookGradeResponse>>> GetAll() {
            throw new NotImplementedException();
        }
    }

}