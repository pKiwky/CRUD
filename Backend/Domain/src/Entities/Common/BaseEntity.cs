using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Common {

    public class BaseEntity {
        [Column("id", Order = 0)]
        public Guid Id { get; set; }
    }

}