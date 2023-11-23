using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class delete_description_from_booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
