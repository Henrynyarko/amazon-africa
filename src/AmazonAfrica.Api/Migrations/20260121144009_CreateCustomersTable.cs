using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonAfrica.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateCustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "amazonafrica");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "amazonafrica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "amazonafrica",
                newName: "Customers");
        }
    }
}
