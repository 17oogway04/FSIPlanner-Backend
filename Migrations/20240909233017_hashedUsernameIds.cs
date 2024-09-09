using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class hashedUsernameIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedUserId",
                table: "User",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashedUsername",
                table: "User",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HashedUsername",
                table: "User");
        }
    }
}
