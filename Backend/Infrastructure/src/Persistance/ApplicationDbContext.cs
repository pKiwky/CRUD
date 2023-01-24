using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance {

    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<DisciplineEntity> Disicplines { get; set; }
        public DbSet<ClassbookEntity> Classbook { get; set; }
        public DbSet<ProfessorEntity> Professors { get; set; }
        public DbSet<ProfessorDisciplineEntity> ProfessorsDisciplines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

}