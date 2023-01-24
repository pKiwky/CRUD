namespace Application.Dto {

    public class UpdateDisciplineRequest {
        public string Name { get; set; }
        public int CourseHours { get; set; }
        public int SeminaryHours { get; set; }
        public int LaboratoryHours { get; set; }
        public int Credits { get; set; }
    }

}