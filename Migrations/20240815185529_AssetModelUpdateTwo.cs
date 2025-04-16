using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class AssetModelUpdateTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "BucketSummary",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "BucketSummary");
        }
    }
}
