using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminSSO.Migrations
{
    public partial class AdddetailtoModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CssClass",
                table: "Module",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Module",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Module",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CssClass",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Module");
        }
    }
}
