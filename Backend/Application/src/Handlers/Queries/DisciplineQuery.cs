using Application.Common.Interfaces;
using Application.Contracts.Queries;
using Application.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class DisciplineQuery : IDisciplineQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public DisciplineQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<IEnumerable<GetDisciplineResponse>>> GetAll() {
            var disciplineEntities = await _applicationDbContext.Disicplines.ToListAsync();

            return new KernelControllerResponse<IEnumerable<GetDisciplineResponse>>(
                disciplineEntities.Adapt<IEnumerable<GetDisciplineResponse>>()
            );
        }
    }

}