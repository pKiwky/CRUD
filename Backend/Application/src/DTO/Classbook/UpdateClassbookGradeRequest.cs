namespace Application.Dto {

    public class UpdateClassbookGradeRequest {
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
    }

}