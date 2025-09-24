using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fsiplanner_backend.Migrations
{
    /// <inheritdoc />
    public partial class Acctmovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcctMovements",
                columns: table => new
                {
                    AcctMovementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullOrPartial = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyFrom = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyTo = table.Column<string>(type: "TEXT", nullable: false),
                    DollarAmt = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcctMovements", x => x.AcctMovementId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcctMovements_UserId",
                table: "AcctMovements",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcctMovements");
        }
    }
}
