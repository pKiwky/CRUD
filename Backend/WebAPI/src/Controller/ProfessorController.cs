using Application.Contracts;
using Application.Contracts.Queries;
using WebAPI.Common;

namespace WebAPI.Controller {

    public class ProfessorController : APIController {
        private readonly IProfessorQuery _professorQuery;
        private readonly IProfessorCommand _professorCommand;
        private readonly IProfessorDisciplineQuery _professorDisciplineQuery;
        private readonly IProfessorDisciplineCommand _professorDisciplineCommand;

        public ProfessorController(IProfessorQuery professorQuery, IProfessorCommand professorCommand, IProfessorDisciplineQuery professorDisciplineQuery, IProfessorDisciplineCommand professorDisciplineCommand) {
            _professorQuery = professorQuery;
            _professorCommand = professorCommand;
            _professorDisciplineQuery = professorDisciplineQuery;
            _professorDisciplineCommand = professorDisciplineCommand;
        }
    }

}