using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities {

    [Table("professors")]
    public class ProfessorEntity : BaseEntity {
        [Column("cnp")]
        public string CNP { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("function")]
        public string Function { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone")]
        public string Phone { get; set; }
    }

}