using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces {

    public interface IApplicationDbContext {
        DbSet<StudentEntity> Students { get; set; }
        DbSet<DisciplineEntity> Disicplines { get; set; }
        DbSet<ClassbookEntity> Classbook { get; set; }
        DbSet<ProfessorEntity> Professors { get; set; }
        DbSet<ProfessorDisciplineEntity> ProfessorsDisciplines { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}