using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class DemoModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "C1",
                table: "Demographics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "C2",
                table: "Demographics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "C3",
                table: "Demographics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "C4",
                table: "Demographics",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spouse",
                table: "Demographics",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "C1",
                table: "Demographics");

            migrationBuilder.DropColumn(
                name: "C2",
                table: "Demographics");

            migrationBuilder.DropColumn(
                name: "C3",
                table: "Demographics");

            migrationBuilder.DropColumn(
                name: "C4",
                table: "Demographics");

            migrationBuilder.DropColumn(
                name: "Spouse",
                table: "Demographics");
        }
    }
}
