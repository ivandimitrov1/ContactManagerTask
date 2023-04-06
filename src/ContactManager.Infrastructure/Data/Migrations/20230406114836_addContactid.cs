using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addContactid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "tContactRead",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "tContactRead");
        }
    }
}
