using Application.Contracts;
using Application.Contracts.Queries;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controller {

    public class ClassbookController : APIController {
        private readonly IClassbookQuery _classbookQuery;
        private readonly IClassbookCommand _classbookCommand;

        public ClassbookController(IClassbookQuery classbookQuery, IClassbookCommand classbookCommand) {
            _classbookQuery = classbookQuery;
            _classbookCommand = classbookCommand;
        }

        [HttpGet("get-student-grades/{id}")]
        public async Task<IActionResult> GetStudentGrade(Guid id) {
            return Handle(await _classbookQuery.GetStudentGrades(id));
        }

        [HttpPost("create-grade")]
        public async Task<IActionResult> Create(CreateClassbookGradeRequest createClassbookGradeRequest) {
            return Handle(await _classbookCommand.CreateClassbookGrade(createClassbookGradeRequest));
        }

        [HttpPut("update-grade/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClassbookGradeRequest updateClassbookGradeRequest) {
            return Handle(await _classbookCommand.UpdateClassbookGrade(id, updateClassbookGradeRequest));
        }

        [HttpDelete("delete-grade/{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            return Handle(await _classbookCommand.DeleteClassbookGrade(id));
        }
    }

}