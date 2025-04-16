using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class BalanceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    BalanceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type1 = table.Column<string>(type: "TEXT", nullable: true),
                    Type2 = table.Column<string>(type: "TEXT", nullable: true),
                    Type3 = table.Column<string>(type: "TEXT", nullable: true),
                    Type4 = table.Column<string>(type: "TEXT", nullable: true),
                    Type5 = table.Column<string>(type: "TEXT", nullable: true),
                    Type6 = table.Column<string>(type: "TEXT", nullable: true),
                    Type7 = table.Column<string>(type: "TEXT", nullable: true),
                    Type8 = table.Column<string>(type: "TEXT", nullable: true),
                    Type9 = table.Column<string>(type: "TEXT", nullable: true),
                    Type10 = table.Column<string>(type: "TEXT", nullable: true),
                    Type11 = table.Column<string>(type: "TEXT", nullable: true),
                    Type12 = table.Column<string>(type: "TEXT", nullable: true),
                    Type13 = table.Column<string>(type: "TEXT", nullable: true),
                    Type14 = table.Column<string>(type: "TEXT", nullable: true),
                    Type15 = table.Column<string>(type: "TEXT", nullable: true),
                    Type16 = table.Column<string>(type: "TEXT", nullable: true),
                    Type17 = table.Column<string>(type: "TEXT", nullable: true),
                    Type18 = table.Column<string>(type: "TEXT", nullable: true),
                    Type19 = table.Column<string>(type: "TEXT", nullable: true),
                    Type20 = table.Column<string>(type: "TEXT", nullable: true),
                    Type21 = table.Column<string>(type: "TEXT", nullable: true),
                    Type22 = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.BalanceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balance_UserId",
                table: "Balance",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance");
        }
    }
}
