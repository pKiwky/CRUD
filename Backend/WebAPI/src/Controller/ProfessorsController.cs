using Application.Contracts;
using Application.Contracts.Queries;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controller {

    public class ProfessorsController : APIController {
        private readonly IProfessorQuery _professorQuery;
        private readonly IProfessorCommand _professorCommand;

        public ProfessorsController(IProfessorQuery professorQuery, IProfessorCommand professorCommand) {
            _professorQuery = professorQuery;
            _professorCommand = professorCommand;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() {
            return Handle(await _professorQuery.GetAll());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProfessorRequest createProfessorRequest) {
            return Handle(await _professorCommand.CreateProfessor(createProfessorRequest));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProfessorRequest updateProfessorRequest) {
            return Handle(await _professorCommand.UpdateProfessor(id, updateProfessorRequest));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            return Handle(await _professorCommand.DeleteProfessor(id));
        }
    }

}