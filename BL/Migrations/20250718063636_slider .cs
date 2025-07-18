using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbSlider",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbSlider");

            
        }
    }
}
