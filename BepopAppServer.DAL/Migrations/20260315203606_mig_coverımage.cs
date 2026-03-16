using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BepopAppServer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_coverımage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Songs");
        }
    }
}
