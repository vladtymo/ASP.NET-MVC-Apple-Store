using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "ImagePath" },
                values: new object[] { "Midnight", "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-finish-select-202209-6-1inch-midnight_1.png" });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "ImagePath" },
                values: new object[] { "Starlight", "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-plus_2__3.jpeg" });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-black-1_4_2.jpeg");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-purple-1_9.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Phones");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "White");
        }
    }
}
