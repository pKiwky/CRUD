using Application.Contracts;
using Application.Dto;

namespace Application.Handlers {

    public class ClassbookCommand : IClassbookCommand {
        public async Task<KernelControllerResponse<CreateClassbookGradeResponse>> CreateClassbookGrade(CreateClassbookGradeRequest createClassbookGradeRequest) {
            throw new NotImplementedException();
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateClassbookGrade(Guid id, UpdateClassbookGradeRequest updateClassbookGradeRequest) {
            throw new NotImplementedException();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteClassbookGrade(Guid id) {
            throw new NotImplementedException();
        }
    }

}