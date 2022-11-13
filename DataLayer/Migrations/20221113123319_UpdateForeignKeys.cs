using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreams_Resolutions_ResolutionId",
                table: "Dreams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Goals_GoalId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Dreams_ResolutionId",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "ResolutionId",
                table: "Dreams");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Goals_GoalId",
                table: "Tasks",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Goals_GoalId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "Dreams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_ResolutionId",
                table: "Dreams",
                column: "ResolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dreams_Resolutions_ResolutionId",
                table: "Dreams",
                column: "ResolutionId",
                principalTable: "Resolutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Goals_GoalId",
                table: "Tasks",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id");
        }
    }
}
