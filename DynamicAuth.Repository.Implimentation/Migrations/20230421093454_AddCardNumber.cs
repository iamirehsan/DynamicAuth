using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicAuth.Repository.Implimentation.Migrations
{
    /// <inheritdoc />
    public partial class AddCardNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BanksCardsNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanksCardsNumber",
                table: "AspNetUsers");
        }
    }
}
