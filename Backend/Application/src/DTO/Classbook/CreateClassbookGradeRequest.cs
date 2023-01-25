namespace Application.Dto {

    public class CreateClassbookGradeRequest {
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
        public int Grade { get; set; }
    }

}