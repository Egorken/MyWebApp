using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Id13011939 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspUserShow",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspUserShow",
                newName: "UserId");
        }
    }
}
