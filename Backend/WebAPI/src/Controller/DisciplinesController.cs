using Application.Contracts;
using Application.Contracts.Queries;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controller {

    public class DisciplinesController : APIController {
        private readonly IDisciplineQuery _disciplineQuery;
        private readonly IDisciplineCommand _disciplineCommand;

        public DisciplinesController(IDisciplineQuery disciplineQuery, IDisciplineCommand disciplineCommand) {
            _disciplineQuery = disciplineQuery;
            _disciplineCommand = disciplineCommand;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() {
            return Handle(await _disciplineQuery.GetAll());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateDisciplineRequest createStudentRequest) {
            return Handle(await _disciplineCommand.CreateDiscipline(createStudentRequest));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDisciplineRequest updateStudentRequest) {
            return Handle(await _disciplineCommand.UpdateDiscipline(id, updateStudentRequest));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            return Handle(await _disciplineCommand.DeleteDiscipline(id));
        }
    }

}