using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ServiceStore.Api.Shop.Migrations
{
    public partial class MySQLInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopSession",
                columns: table => new
                {
                    ShopSessionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSession", x => x.ShopSessionId);
                });

            migrationBuilder.CreateTable(
                name: "ShopSessionDetail",
                columns: table => new
                {
                    ShopSessionDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    SelectedProduct = table.Column<string>(nullable: true),
                    ShopSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSessionDetail", x => x.ShopSessionDetailId);
                    table.ForeignKey(
                        name: "FK_ShopSessionDetail_ShopSession_ShopSessionId",
                        column: x => x.ShopSessionId,
                        principalTable: "ShopSession",
                        principalColumn: "ShopSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSessionDetail_ShopSessionId",
                table: "ShopSessionDetail",
                column: "ShopSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopSessionDetail");

            migrationBuilder.DropTable(
                name: "ShopSession");
        }
    }
}
