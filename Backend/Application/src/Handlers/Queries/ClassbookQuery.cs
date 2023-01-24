using Application.Common.Interfaces;
using Application.Contracts.Queries;
using Application.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class ClassbookQuery : IClassbookQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public ClassbookQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<IEnumerable<GetClassbookGradeResponse>>> GetStudentGrades(Guid id) {
            var studentEntities = await _applicationDbContext.Classbook
                .Where(c => c.StudentId == id)
                .ToListAsync();

            return new KernelControllerResponse<IEnumerable<GetClassbookGradeResponse>>(
                studentEntities.Adapt<IEnumerable<GetClassbookGradeResponse>>()
            );
        }

    }

}