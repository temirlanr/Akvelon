using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.Migrations
{
    public partial class AddedCourseGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrade_Courses_CourseId",
                table: "CourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrade_Students_CourseId",
                table: "CourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonsGrades_Lessons_LessonId",
                table: "LessonsGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonsGrades_Students_StudentId",
                table: "LessonsGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonsGrades",
                table: "LessonsGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseGrade",
                table: "CourseGrade");

            migrationBuilder.RenameTable(
                name: "LessonsGrades",
                newName: "LessonGrades");

            migrationBuilder.RenameTable(
                name: "CourseGrade",
                newName: "CourseGrades");

            migrationBuilder.RenameIndex(
                name: "IX_LessonsGrades_StudentId",
                table: "LessonGrades",
                newName: "IX_LessonGrades_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonsGrades_LessonId",
                table: "LessonGrades",
                newName: "IX_LessonGrades_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseGrade_CourseId",
                table: "CourseGrades",
                newName: "IX_CourseGrades_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonGrades",
                table: "LessonGrades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseGrades",
                table: "CourseGrades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrades_Courses_CourseId",
                table: "CourseGrades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrades_Students_CourseId",
                table: "CourseGrades",
                column: "CourseId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonGrades_Lessons_LessonId",
                table: "LessonGrades",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonGrades_Students_StudentId",
                table: "LessonGrades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrades_Courses_CourseId",
                table: "CourseGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrades_Students_CourseId",
                table: "CourseGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonGrades_Lessons_LessonId",
                table: "LessonGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonGrades_Students_StudentId",
                table: "LessonGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonGrades",
                table: "LessonGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseGrades",
                table: "CourseGrades");

            migrationBuilder.RenameTable(
                name: "LessonGrades",
                newName: "LessonsGrades");

            migrationBuilder.RenameTable(
                name: "CourseGrades",
                newName: "CourseGrade");

            migrationBuilder.RenameIndex(
                name: "IX_LessonGrades_StudentId",
                table: "LessonsGrades",
                newName: "IX_LessonsGrades_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonGrades_LessonId",
                table: "LessonsGrades",
                newName: "IX_LessonsGrades_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseGrades_CourseId",
                table: "CourseGrade",
                newName: "IX_CourseGrade_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonsGrades",
                table: "LessonsGrades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseGrade",
                table: "CourseGrade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrade_Courses_CourseId",
                table: "CourseGrade",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrade_Students_CourseId",
                table: "CourseGrade",
                column: "CourseId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonsGrades_Lessons_LessonId",
                table: "LessonsGrades",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonsGrades_Students_StudentId",
                table: "LessonsGrades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
