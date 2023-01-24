using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    coursehours = table.Column<int>(name: "course_hours", type: "integer", nullable: false),
                    seminaryhours = table.Column<int>(name: "seminary_hours", type: "integer", nullable: false),
                    laboratoryhours = table.Column<int>(name: "laboratory_hours", type: "integer", nullable: false),
                    credits = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cnp = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: false),
                    function = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: false),
                    department = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    sex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professors_disciplines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    professorid = table.Column<Guid>(name: "professor_id", type: "uuid", nullable: false),
                    disciplineid = table.Column<Guid>(name: "discipline_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professors_disciplines", x => x.id);
                    table.ForeignKey(
                        name: "FK_professors_disciplines_disciplines_discipline_id",
                        column: x => x.disciplineid,
                        principalTable: "disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professors_disciplines_professors_professor_id",
                        column: x => x.professorid,
                        principalTable: "professors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classbook",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    studentid = table.Column<Guid>(name: "student_id", type: "uuid", nullable: false),
                    disciplineid = table.Column<Guid>(name: "discipline_id", type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classbook", x => x.id);
                    table.ForeignKey(
                        name: "FK_classbook_disciplines_discipline_id",
                        column: x => x.disciplineid,
                        principalTable: "disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classbook_students_student_id",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classbook_discipline_id",
                table: "classbook",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_classbook_student_id",
                table: "classbook",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_professors_disciplines_discipline_id",
                table: "professors_disciplines",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_professors_disciplines_professor_id",
                table: "professors_disciplines",
                column: "professor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classbook");

            migrationBuilder.DropTable(
                name: "professors_disciplines");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.DropTable(
                name: "professors");
        }
    }
}
