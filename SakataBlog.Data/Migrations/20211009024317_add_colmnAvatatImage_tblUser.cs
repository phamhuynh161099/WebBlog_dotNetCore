using Microsoft.EntityFrameworkCore.Migrations;

namespace SakataBlog.Data.Migrations
{
    public partial class add_colmnAvatatImage_tblUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarImage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "Users");
        }
    }
}
