using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLab01.Migrations
{
    /// <inheritdoc />
    public partial class userPasswordNotNull1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4b2dc711-8bec-40e0-a10f-a30d2d05f5ad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8740ea52-53b2-47c4-beda-ded589f9455a");
        }
    }
}
