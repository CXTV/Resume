using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumenManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class companySizeToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Jobs",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Companies",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Candidates",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Jobs",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Companies",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Candidates",
                newName: "isActive");
        }
    }
}
