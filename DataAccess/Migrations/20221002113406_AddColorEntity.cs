using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddColorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Phones");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "Silver" },
                    { 3, "Space Black" },
                    { 4, "Space Grey" },
                    { 5, "Deep Purple" },
                    { 6, "Starlight" },
                    { 7, "Green" },
                    { 8, "Gold" },
                    { 9, "Sierra Blue" },
                    { 10, "Midnight" }
                });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "ColorId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "ColorId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "ColorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "ColorId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ColorId",
                table: "Phones",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Colors_ColorId",
                table: "Phones",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Colors_ColorId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Phones_ColorId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "Midnight");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "Starlight");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "Color",
                value: "Space Black");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "Deep Purple");
        }
    }
}
