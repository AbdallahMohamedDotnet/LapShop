using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShopv2.Migrations
{
    /// <inheritdoc />
    public partial class Add_WebSiteSetting_feature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBSettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    webSiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSiteDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FaceBookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instegramLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSettings", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBSettings");
        }
    }
}
