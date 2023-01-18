using Application.Contracts;
using Application.DTO.Student;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controller {

    public class StudentsController : APIController {
        private readonly IStudentCommand _studentCommand;

        public StudentsController(IStudentCommand studentCommand) {
            _studentCommand = studentCommand;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateStudentRequest createStudentRequest) {
            return Handle(await _studentCommand.CreateStudent(createStudentRequest));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(Guid id) {
            return Handle(await _studentCommand.DeleteStudent(id));
        }
    }

}