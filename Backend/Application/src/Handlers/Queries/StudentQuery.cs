using Application.Common.Interfaces;
using Application.Contracts.Queries;
using Application.Dto;
using Application.DTO.Student;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class StudentQuery : IStudentQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public StudentQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<IEnumerable<GetStudentResponse>>> GetAll() {
            var studentEntities = await _applicationDbContext.Students.ToListAsync();
            return new KernelControllerResponse<IEnumerable<GetStudentResponse>>(
                studentEntities.Adapt<IEnumerable<GetStudentResponse>>()
            );
        }
    }

}