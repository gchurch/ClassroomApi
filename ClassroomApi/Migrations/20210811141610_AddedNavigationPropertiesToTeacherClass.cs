using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassroomApi.Migrations
{
    public partial class AddedNavigationPropertiesToTeacherClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_ClassId",
                table: "TeacherClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_TeacherId",
                table: "TeacherClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClasses_Classes_ClassId",
                table: "TeacherClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClasses_Teachers_TeacherId",
                table: "TeacherClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClasses_Classes_ClassId",
                table: "TeacherClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClasses_Teachers_TeacherId",
                table: "TeacherClasses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClasses_ClassId",
                table: "TeacherClasses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClasses_TeacherId",
                table: "TeacherClasses");
        }
    }
}
