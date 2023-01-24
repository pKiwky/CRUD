using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities {

    [Table("disciplines")]
    public class DisciplineEntity : BaseEntity {
        [Column("name")]
        public string Name { get; set; }

        [Column("course_hours")]
        public int CourseHours { get; set; }

        [Column("seminary_hours")]
        public int SeminaryHours { get; set; }

        [Column("laboratory_hours")]
        public int LaboratoryHours { get; set; }

        [Column("credits")]
        public int Credits { get; set; }
    }

}