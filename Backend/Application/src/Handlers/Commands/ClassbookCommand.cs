using Application.Common.Interfaces;
using Application.Contracts;
using Application.Dto;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class ClassbookCommand : IClassbookCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public ClassbookCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<CreateClassbookGradeResponse>> CreateClassbookGrade(CreateClassbookGradeRequest createClassbookGradeRequest) {
            var classbookEntity = await _applicationDbContext.Classbook
                .FirstOrDefaultAsync(c => c.StudentId == createClassbookGradeRequest.StudentId && c.DisciplineId == createClassbookGradeRequest.DisciplineId);

            // Edit current grade.
            if (classbookEntity != null) {
                classbookEntity.Grade = createClassbookGradeRequest.Grade;
            }
            // Add new grade.
            else {
                classbookEntity = createClassbookGradeRequest.Adapt<ClassbookEntity>();
                classbookEntity.Date = DateTime.Now;
                _applicationDbContext.Classbook.Add(classbookEntity);
            }

            if (await _applicationDbContext.SaveChangesAsync() != 0) {
                return new KernelControllerResponse<CreateClassbookGradeResponse>(new CreateClassbookGradeResponse() {
                    Id = classbookEntity.Id
                });
            }

            return new KernelControllerResponse<CreateClassbookGradeResponse>().AddError("UnknownError", "An unknown error occurred.");
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateClassbookGrade(Guid id, UpdateClassbookGradeRequest updateClassbookGradeRequest) {
            var classbookEntity = await _applicationDbContext.Classbook.FirstOrDefaultAsync(s => s.Id == id);

            if (classbookEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            updateClassbookGradeRequest.Adapt(classbookEntity);

            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteClassbookGrade(Guid id) {
            var classbookEntity = await _applicationDbContext.Classbook.FirstOrDefaultAsync(s => s.Id == id);

            if (classbookEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            _applicationDbContext.Classbook.Remove(classbookEntity);

            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }
    }

}
