using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ServiceStore.Api.Author.Migrations
{
    public partial class InitialPostgresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorBookId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    AuthorBookGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => x.AuthorBookId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGrade",
                columns: table => new
                {
                    AcademicGradeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    GraduationDate = table.Column<DateTime>(nullable: true),
                    AuthorBookId = table.Column<int>(nullable: false),
                    AcademicGradeGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGrade", x => x.AcademicGradeId);
                    table.ForeignKey(
                        name: "FK_AcademicGrade_AuthorBook_AuthorBookId",
                        column: x => x.AuthorBookId,
                        principalTable: "AuthorBook",
                        principalColumn: "AuthorBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGrade_AuthorBookId",
                table: "AcademicGrade",
                column: "AuthorBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGrade");

            migrationBuilder.DropTable(
                name: "AuthorBook");
        }
    }
}
