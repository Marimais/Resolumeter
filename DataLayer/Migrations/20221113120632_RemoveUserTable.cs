using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resolutions_Users_UserId",
                table: "Resolutions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Resolutions_UserId",
                table: "Resolutions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Resolutions");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Resolutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Resolutions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Resolutions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_UserId",
                table: "Resolutions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resolutions_Users_UserId",
                table: "Resolutions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
