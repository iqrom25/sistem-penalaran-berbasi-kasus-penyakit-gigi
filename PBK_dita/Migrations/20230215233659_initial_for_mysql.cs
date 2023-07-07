using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PBK_dita.Migrations
{
    public partial class initial_for_mysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_gejala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    kode_gejala = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Bobot = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_gejala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_penyakit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    kode_penyakit = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Solusi = table.Column<string>(type: "text", nullable: false),
                    Gambar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_penyakit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "varchar(767)", nullable: false),
                    Umur = table.Column<int>(type: "int", nullable: false),
                    jenis_kelamin = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_rekam_medis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_kasus = table.Column<int>(type: "int", nullable: false),
                    tanggal_input = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    PenyakitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_rekam_medis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_m_rekam_medis_m_penyakit_PenyakitId",
                        column: x => x.PenyakitId,
                        principalTable: "m_penyakit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RiwayatKonsultasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tanggal_input = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PenyakitId = table.Column<int>(type: "int", nullable: true),
                    Similiarity = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatKonsultasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiwayatKonsultasi_m_penyakit_PenyakitId",
                        column: x => x.PenyakitId,
                        principalTable: "m_penyakit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiwayatKonsultasi_m_user_UserId",
                        column: x => x.UserId,
                        principalTable: "m_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GejalaRekamMedis",
                columns: table => new
                {
                    ListGejalaId = table.Column<int>(type: "int", nullable: false),
                    ListRekamMedisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GejalaRekamMedis", x => new { x.ListGejalaId, x.ListRekamMedisId });
                    table.ForeignKey(
                        name: "FK_GejalaRekamMedis_m_gejala_ListGejalaId",
                        column: x => x.ListGejalaId,
                        principalTable: "m_gejala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GejalaRekamMedis_m_rekam_medis_ListRekamMedisId",
                        column: x => x.ListRekamMedisId,
                        principalTable: "m_rekam_medis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GejalaRiwayatKonsultasi",
                columns: table => new
                {
                    ListGejalaId = table.Column<int>(type: "int", nullable: false),
                    ListRiwayatKonsultasiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GejalaRiwayatKonsultasi", x => new { x.ListGejalaId, x.ListRiwayatKonsultasiId });
                    table.ForeignKey(
                        name: "FK_GejalaRiwayatKonsultasi_m_gejala_ListGejalaId",
                        column: x => x.ListGejalaId,
                        principalTable: "m_gejala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GejalaRiwayatKonsultasi_RiwayatKonsultasi_ListRiwayatKonsult~",
                        column: x => x.ListRiwayatKonsultasiId,
                        principalTable: "RiwayatKonsultasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GejalaRekamMedis_ListRekamMedisId",
                table: "GejalaRekamMedis",
                column: "ListRekamMedisId");

            migrationBuilder.CreateIndex(
                name: "IX_GejalaRiwayatKonsultasi_ListRiwayatKonsultasiId",
                table: "GejalaRiwayatKonsultasi",
                column: "ListRiwayatKonsultasiId");

            migrationBuilder.CreateIndex(
                name: "IX_m_gejala_kode_gejala",
                table: "m_gejala",
                column: "kode_gejala",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_m_penyakit_kode_penyakit",
                table: "m_penyakit",
                column: "kode_penyakit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_m_rekam_medis_PenyakitId",
                table: "m_rekam_medis",
                column: "PenyakitId");

            migrationBuilder.CreateIndex(
                name: "IX_m_user_Email",
                table: "m_user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatKonsultasi_PenyakitId",
                table: "RiwayatKonsultasi",
                column: "PenyakitId");

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatKonsultasi_UserId",
                table: "RiwayatKonsultasi",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GejalaRekamMedis");

            migrationBuilder.DropTable(
                name: "GejalaRiwayatKonsultasi");

            migrationBuilder.DropTable(
                name: "m_rekam_medis");

            migrationBuilder.DropTable(
                name: "m_gejala");

            migrationBuilder.DropTable(
                name: "RiwayatKonsultasi");

            migrationBuilder.DropTable(
                name: "m_penyakit");

            migrationBuilder.DropTable(
                name: "m_user");
        }
    }
}
