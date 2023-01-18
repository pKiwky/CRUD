using Application.Contracts;
using Application.Contracts.Queries;
using Application.DTO.Student;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controller {

    public class StudentsController : APIController {
        private readonly IStudentCommand _studentCommand;
        private readonly IStudentQuery _studentQuery;

        public StudentsController(IStudentCommand studentCommand, IStudentQuery studentQuery) {
            _studentCommand = studentCommand;
            _studentQuery = studentQuery;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() {
            return Handle(await _studentQuery.GetAll());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateStudentRequest createStudentRequest) {
            return Handle(await _studentCommand.CreateStudent(createStudentRequest));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, UpdateStudentRequest updateStudentRequest) {
            return Handle(await _studentCommand.UpdateStudent(id, updateStudentRequest));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            return Handle(await _studentCommand.DeleteStudent(id));
        }

    }

}