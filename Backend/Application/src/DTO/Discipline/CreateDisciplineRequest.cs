namespace Application.Dto {

    public class CreateDisciplineRequest {
        public string Name { get; set; }
        public int CourseHours { get; set; }
        public int SeminaryHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int Credits { get; set; }
    }

}