using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLab01.Migrations
{
    /// <inheritdoc />
    public partial class userPasswordNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8740ea52-53b2-47c4-beda-ded589f9455a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "534bd528-4fad-4dc1-b24b-7a8f7847497a");
        }
    }
}
