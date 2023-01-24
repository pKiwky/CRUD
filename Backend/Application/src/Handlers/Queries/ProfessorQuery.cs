using Application.Common.Interfaces;
using Application.Contracts.Queries;
using Application.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class ProfessorQuery : IProfessorQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProfessorQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<IEnumerable<GetProfessorResponse>>> GetAll() {
            var professorEntities = await _applicationDbContext.Professors.ToListAsync();

            return new KernelControllerResponse<IEnumerable<GetProfessorResponse>>(
                professorEntities.Adapt<IEnumerable<GetProfessorResponse>>()
            );
        }

        public async Task<KernelControllerResponse<IEnumerable<GetProfessorDisciplineResponse>>> GetAllProfessorDiscipline(Guid id) {
            var professorDisciplineEntities = await _applicationDbContext.ProfessorsDisciplines
                .Where(pd => pd.ProfessorId == id)
                .ToListAsync();

            return new KernelControllerResponse<IEnumerable<GetProfessorDisciplineResponse>>(
                professorDisciplineEntities.Adapt<IEnumerable<GetProfessorDisciplineResponse>>()
            );
        }
    }

}