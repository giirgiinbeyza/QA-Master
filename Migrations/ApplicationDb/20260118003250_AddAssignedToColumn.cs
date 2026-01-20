using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DermaLogic.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddAssignedToColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "TestCases",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "TestCases");
        }
    }
}
