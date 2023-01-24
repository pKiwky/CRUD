using Application.Common.Interfaces;
using Application.Contracts;
using Application.Dto;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class DisciplineCommand : IDisciplineCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public DisciplineCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<CreateDisciplineResponse>> CreateDiscipline(CreateDisciplineRequest createDisciplineRequest) {
            var disciplineEntity = createDisciplineRequest.Adapt<DisciplineEntity>();

            _applicationDbContext.Disicplines.Add(disciplineEntity);
            if (await _applicationDbContext.SaveChangesAsync() != 0) {
                return new KernelControllerResponse<CreateDisciplineResponse>(new CreateDisciplineResponse() {
                    Id = disciplineEntity.Id
                });
            }

            return new KernelControllerResponse<CreateDisciplineResponse>().AddError("UnknownError", "An unknown error occurred.");
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateDiscipline(Guid id, UpdateDisciplineRequest updateDisciplineRequest) {
            var diciplineEntity = await _applicationDbContext.Disicplines.FirstOrDefaultAsync(s => s.Id == id);

            if (diciplineEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            updateDisciplineRequest.Adapt(diciplineEntity);
            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteDiscipline(Guid id) {
            var diciplineEntity = await _applicationDbContext.Disicplines.FirstOrDefaultAsync(s => s.Id == id);

            if (diciplineEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            _applicationDbContext.Disicplines.Remove(diciplineEntity);
            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }
    }

}