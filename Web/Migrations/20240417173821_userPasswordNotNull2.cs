using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendLab01.Migrations
{
    /// <inheritdoc />
    public partial class userPasswordNotNull2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4a2ae6d5-dc60-4a4c-85e3-9bce5d5a242f");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "4b2dc711-8bec-40e0-a10f-a30d2d05f5ad", "strong" });
        }
    }
}
