using Microsoft.EntityFrameworkCore.Migrations;

namespace JeuDontOnEstLeHeros.Core.Data.Migrations
{
    public partial class QuestionsReponseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses");

            migrationBuilder.RenameTable(
                name: "Reponses",
                newName: "Proposition");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Proposition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proposition",
                table: "Proposition",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proposition_QuestionId",
                table: "Proposition",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposition_Question_QuestionId",
                table: "Proposition",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposition_Question_QuestionId",
                table: "Proposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proposition",
                table: "Proposition");

            migrationBuilder.DropIndex(
                name: "IX_Proposition_QuestionId",
                table: "Proposition");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Proposition");

            migrationBuilder.RenameTable(
                name: "Proposition",
                newName: "Reponses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses",
                column: "Id");
        }
    }
}
