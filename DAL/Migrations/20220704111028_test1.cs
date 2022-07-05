using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_AddressId1",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_AddressId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "People");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "People",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_AddressId",
                table: "People",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_AddressId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_AddressId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "People",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AddressId1",
                table: "People",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId1",
                table: "People",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_AddressId1",
                table: "People",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
