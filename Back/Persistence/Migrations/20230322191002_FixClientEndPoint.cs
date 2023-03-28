using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixClientEndPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarLoads_Clients_ClientId",
                table: "CarLoads");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "CarLoads",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CarLoads_ClientId",
                table: "CarLoads",
                newName: "IX_CarLoads_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarLoads_People_PersonId",
                table: "CarLoads",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarLoads_People_PersonId",
                table: "CarLoads");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "CarLoads",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_CarLoads_PersonId",
                table: "CarLoads",
                newName: "IX_CarLoads_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarLoads_Clients_ClientId",
                table: "CarLoads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
