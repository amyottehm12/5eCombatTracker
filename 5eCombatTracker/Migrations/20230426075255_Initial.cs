using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5eCombatTracker.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "monster",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: true),
                    CR = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    AC = table.Column<int>(type: "integer", nullable: true),
                    HP = table.Column<int>(type: "integer", nullable: true),
                    Speed = table.Column<string>(type: "text", nullable: true),
                    Alignment = table.Column<string>(type: "text", nullable: true),
                    Legendary = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    _Str = table.Column<decimal>(type: "numeric", nullable: true),
                    _Dex = table.Column<decimal>(type: "numeric", nullable: true),
                    _Con = table.Column<decimal>(type: "numeric", nullable: true),
                    _Int = table.Column<decimal>(type: "numeric", nullable: true),
                    _Wis = table.Column<decimal>(type: "numeric", nullable: true),
                    _Cha = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monster", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "monster");
        }
    }
}
