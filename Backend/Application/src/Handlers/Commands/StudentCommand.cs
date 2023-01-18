using Application.Common.Interfaces;
using Application.Contracts;
using Application.Dto;
using Application.DTO.Student;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class StudentCommand : IStudentCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public StudentCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<CreateStudentResponse>> CreateStudent(CreateStudentRequest createStudentRequest) {
            var studentEntity = createStudentRequest.Adapt<StudentEntity>();

            _applicationDbContext.Students.Add(studentEntity);
            if (await _applicationDbContext.SaveChangesAsync() != 0) {
                return new KernelControllerResponse<CreateStudentResponse>(new CreateStudentResponse() {
                    Id = studentEntity.Id
                });
            }

            return new KernelControllerResponse<CreateStudentResponse>().AddError("UnknownError", "An unknown error occurred.");
        }

        public async Task<KernelControllerResponse<KernelDeleteResponse>> DeleteStudent(Guid id) {
            var studentEntity = await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (studentEntity == null) {
                return new KernelControllerResponse<KernelDeleteResponse>().AddError("NotFound", "Entity was not found.");
            }

            _applicationDbContext.Students.Remove(studentEntity);

            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelDeleteResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelDeleteResponse>();
        }
    }

}