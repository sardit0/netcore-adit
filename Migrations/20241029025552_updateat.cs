using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventaris.Migrations
{
    /// <inheritdoc />
    public partial class updateat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "Category",
                newName: "UpdateAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Category",
                newName: "LastUpdate");
        }
    }
}
