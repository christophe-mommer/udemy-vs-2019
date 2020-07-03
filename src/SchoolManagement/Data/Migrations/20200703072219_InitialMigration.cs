using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseParticipation",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Notation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseParticipation", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseParticipation_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseParticipation_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[] { 1, "Smith", "Paul" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[] { 2, "London", "Jack" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[] { 3, "MacDonald", "John" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[] { 4, "Sharp", "Will" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Lastname", "Name" },
                values: new object[] { 1, "Doe", "John" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Lastname", "Name" },
                values: new object[] { 2, "Smith", "John" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Lastname", "Name" },
                values: new object[] { 3, "Data", "Mark" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Hours", "Name", "TeacherId" },
                values: new object[] { 1, 36, "Learn C#", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Hours", "Name", "TeacherId" },
                values: new object[] { 2, 24, "Learn WPF", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Hours", "Name", "TeacherId" },
                values: new object[] { 3, 44, "Learn ASP.NET Core", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Hours", "Name", "TeacherId" },
                values: new object[] { 6, 10, "Learn Azure DevOps", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Hours", "Name", "TeacherId" },
                values: new object[] { 4, 16, "Learn EF Core", 3 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Hours", "Name", "TeacherId" },
                values: new object[] { 5, 52, "Learn Azure", 3 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 1, 1, 13 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 5, 1, 11 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 4, 4, 20 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 4, 3, 12 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 4, 2, 18 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 4, 1, 11 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 3, 4, 12 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 3, 3, 16 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 5, 2, 10 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 3, 2, 17 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 2, 4, 15 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 2, 3, 5 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 2, 2, 8 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 2, 1, 11 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 1, 4, 19 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 1, 3, 8 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 1, 2, 15 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 3, 1, 17 });

            migrationBuilder.InsertData(
                table: "CourseParticipation",
                columns: new[] { "CourseId", "StudentId", "Notation" },
                values: new object[] { 5, 3, 11 });

            migrationBuilder.CreateIndex(
                name: "IX_CourseParticipation_StudentId",
                table: "CourseParticipation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseParticipation");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
