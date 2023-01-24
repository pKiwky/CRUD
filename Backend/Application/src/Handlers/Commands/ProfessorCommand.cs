using Application.Common.Interfaces;
using Application.Contracts;
using Application.Dto;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers {

    public class ProfessorCommand : IProfessorCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProfessorCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<KernelControllerResponse<CreateProfessorResponse>> CreateProfessor(CreateProfessorRequest createProfessorRequest) {
            var professorEntity = createProfessorRequest.Adapt<ProfessorEntity>();

            _applicationDbContext.Professors.Add(professorEntity);
            if (await _applicationDbContext.SaveChangesAsync() != 0) {
                return new KernelControllerResponse<CreateProfessorResponse>(new CreateProfessorResponse() {
                    Id = professorEntity.Id
                });
            }

            return new KernelControllerResponse<CreateProfessorResponse>().AddError("UnknownError", "An unknown error occurred.");
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateProfessor(Guid id, UpdateProfessorRequest updateProfessorRequest) {
            var professorEntity = await _applicationDbContext.Professors.FirstOrDefaultAsync(s => s.Id == id);

            if (professorEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            updateProfessorRequest.Adapt(professorEntity);
            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteProfessor(Guid id) {
            var professorEntity = await _applicationDbContext.Professors.FirstOrDefaultAsync(s => s.Id == id);

            if (professorEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            _applicationDbContext.Professors.Remove(professorEntity);
            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }

        public async Task<KernelControllerResponse<CreateProfessorDisciplineResponse>> CreateProfessorDiscipline(CreateProfessorDisciplineRequest createProfessorDisciplineRequest) {
            var professorDisciplineEntity = createProfessorDisciplineRequest.Adapt<ProfessorDisciplineEntity>();

            _applicationDbContext.ProfessorsDisciplines.Add(professorDisciplineEntity);
            if (await _applicationDbContext.SaveChangesAsync() != 0) {
                return new KernelControllerResponse<CreateProfessorDisciplineResponse>(new CreateProfessorDisciplineResponse() {
                    Id = professorDisciplineEntity.Id
                });
            }

            return new KernelControllerResponse<CreateProfessorDisciplineResponse>().AddError("UnknownError", "An unknown error occurred.");
        }

        public async Task<KernelControllerResponse<KernelResponse>> UpdateProfessorDiscipline(Guid id, UpdateProfessorDisciplineRequest updateProfessorDisciplineRequest) {
            var professorDisciplineEntity = await _applicationDbContext.ProfessorsDisciplines.FirstOrDefaultAsync(s => s.Id == id);

            if (professorDisciplineEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            updateProfessorDisciplineRequest.Adapt(professorDisciplineEntity);
            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }

        public async Task<KernelControllerResponse<KernelResponse>> DeleteProfessorDiscipline(Guid id) {
            var professorDisciplineEntity = await _applicationDbContext.ProfessorsDisciplines.FirstOrDefaultAsync(s => s.Id == id);

            if (professorDisciplineEntity == null) {
                return new KernelControllerResponse<KernelResponse>().AddNotFoundError();
            }

            _applicationDbContext.ProfessorsDisciplines.Remove(professorDisciplineEntity);
            if (await _applicationDbContext.SaveChangesAsync() == 0) {
                return new KernelControllerResponse<KernelResponse>().AddError("UnknownError", "An unknown error occurred.");
            }

            return new KernelControllerResponse<KernelResponse>();
        }
    }

}