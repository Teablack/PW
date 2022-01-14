using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProducersRelation",
                columns: table => new
                {
                    GUID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducersRelation", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "TabletsRelation",
                columns: table => new
                {
                    GUID = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    ProducerGUID = table.Column<string>(type: "TEXT", nullable: false),
                    Display = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabletsRelation", x => x.GUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProducersRelation");

            migrationBuilder.DropTable(
                name: "TabletsRelation");
        }
    }
}
