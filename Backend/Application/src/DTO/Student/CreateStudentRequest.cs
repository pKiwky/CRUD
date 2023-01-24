namespace Application.Dto {

    public class CreateStudentRequest {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
        public int Sex { get; set; }
    }

}