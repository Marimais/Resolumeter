using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenameYearBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResolutionYear",
                table: "Resolutions",
                newName: "Year");

            migrationBuilder.RenameIndex(
                name: "IX_Resolutions_UserName_ResolutionYear",
                table: "Resolutions",
                newName: "IX_Resolutions_UserName_Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Resolutions",
                newName: "ResolutionYear");

            migrationBuilder.RenameIndex(
                name: "IX_Resolutions_UserName_Year",
                table: "Resolutions",
                newName: "IX_Resolutions_UserName_ResolutionYear");
        }
    }
}
