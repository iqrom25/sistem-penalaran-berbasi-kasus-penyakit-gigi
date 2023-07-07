using Microsoft.EntityFrameworkCore.Migrations;

namespace PBK_dita.Migrations
{
    public partial class remove_id_kasus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_kasus",
                table: "m_rekam_medis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_kasus",
                table: "m_rekam_medis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
