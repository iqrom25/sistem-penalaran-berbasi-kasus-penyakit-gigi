using Microsoft.EntityFrameworkCore.Migrations;

namespace PBK_dita.Migrations
{
    public partial class remove_bobot_from_gejala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bobot",
                table: "m_gejala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Bobot",
                table: "m_gejala",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
