using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class assetModelFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Asset",
                newName: "AssetName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssetName",
                table: "Asset",
                newName: "Name");
        }
    }
}
