using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities {

    [Table("professors_disciplines")]
    public class ProfessorDisciplineEntity : BaseEntity {
        [Column("professor_id")]
        [ForeignKey(nameof(ProfessorEntity.Id))]
        public Guid ProfessorId { get; set; }

        [Column("discipline_id")]
        [ForeignKey(nameof(DisciplineEntity.Id))]
        public Guid DisciplineId { get; set; }

        [Column("course")]
        public bool Course;

        [Column("seminary")]
        public bool Seminary;

        [Column("laboratory")]
        public bool Laboratory;

        public ProfessorEntity Professor { get; set; }
        public DisciplineEntity Discipline { get; set; }
    }

}