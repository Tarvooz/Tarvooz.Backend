using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarvooz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fivth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SearchCount",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SearchPatterns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SearchWord = table.Column<string>(type: "text", nullable: false),
                    SearchCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchPatterns", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchPatterns");

            migrationBuilder.DropColumn(
                name: "SearchCount",
                table: "Categories");
        }
    }
}
