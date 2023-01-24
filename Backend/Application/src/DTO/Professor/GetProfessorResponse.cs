namespace Application.Dto {

    public class GetProfessorResponse {
        public Guid Id { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

}