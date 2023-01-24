namespace Application.Dto {

    public class GetProfessorDisciplineResponse {
        public Guid Id { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid DisciplineId { get; set; }
        public bool Course;
        public bool Seminary;
        public bool Laboratory;
    }

}