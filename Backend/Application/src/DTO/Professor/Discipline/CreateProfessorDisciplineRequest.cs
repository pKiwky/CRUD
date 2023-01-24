namespace Application.Dto {

    public class CreateProfessorDisciplineRequest {
        public Guid ProfessorId { get; set; }
        public Guid DisciplineId { get; set; }
        public bool Course;
        public bool Seminary;
        public bool Laboratory;
    }

}