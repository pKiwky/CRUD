using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities {

    [Table("classbook")]
    public class ClassbookEntity : BaseEntity {
        [Column("student_id")]
        [ForeignKey(nameof(StudentEntity.Id))]
        public Guid StudentId { get; set; }

        [Column("discipline_id")]
        [ForeignKey(nameof(DisciplineEntity.Id))]
        public Guid DisciplineId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("grade")]
        public int Grade { get; set; }

        public StudentEntity Student { get; set; }
        public DisciplineEntity Discipline { get; set; }
    }

}