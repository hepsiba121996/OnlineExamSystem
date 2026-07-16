using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExamSystem.Migrations
{
    /// <inheritdoc />
    public partial class addresult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marks",
                table: "results");

            migrationBuilder.RenameColumn(
                name: "WrongAnswers",
                table: "results",
                newName: "Score");

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "results",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_results_StudentExamId",
                table: "results",
                column: "StudentExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_results_StudentExam_StudentExamId",
                table: "results",
                column: "StudentExamId",
                principalTable: "StudentExam",
                principalColumn: "StudentExamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_results_StudentExam_StudentExamId",
                table: "results");

            migrationBuilder.DropIndex(
                name: "IX_results_StudentExamId",
                table: "results");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "results");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "results",
                newName: "WrongAnswers");

            migrationBuilder.AddColumn<int>(
                name: "Marks",
                table: "results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
