using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class BalanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Balance",
                table: "Balance");

            migrationBuilder.RenameTable(
                name: "Balance",
                newName: "Balances");

            migrationBuilder.RenameIndex(
                name: "IX_Balance_UserId",
                table: "Balances",
                newName: "IX_Balances_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Balances",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balances",
                table: "Balances",
                column: "BalanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Balances",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Balances");

            migrationBuilder.RenameTable(
                name: "Balances",
                newName: "Balance");

            migrationBuilder.RenameIndex(
                name: "IX_Balances_UserId",
                table: "Balance",
                newName: "IX_Balance_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balance",
                table: "Balance",
                column: "BalanceId");
        }
    }
}
