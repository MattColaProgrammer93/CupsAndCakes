using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CupsAndCakes.Data.Migrations
{
    public partial class PersonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_PersonId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_PersonId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
