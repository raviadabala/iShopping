using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iShopping.SchemaBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddKnownAs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "KnownAs" },
                values: new object[] { "714aafd5-985b-488a-89f5-1b06f3ef5669", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1a8692c3-c8bb-4dda-b8e2-7ecfa34d88b0");
        }
    }
}
