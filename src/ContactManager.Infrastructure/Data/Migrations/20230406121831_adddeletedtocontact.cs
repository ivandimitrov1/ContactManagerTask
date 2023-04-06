using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddeletedtocontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "tContact",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "tContact");
        }
    }
}
