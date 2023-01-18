using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities {

    [Table("students")]
    public class StudentEntity : BaseEntity {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("department")]
        public string Department { get; set; }
        
        [Column("year")]
        public int Year { get; set; }
        
        [Column("sex")]
        public int Sex { get; set; }
    }

}