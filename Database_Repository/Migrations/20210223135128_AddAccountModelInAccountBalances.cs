using Microsoft.EntityFrameworkCore.Migrations;

namespace Database_Repository.Migrations
{
    public partial class AddAccountModelInAccountBalances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_AccountId",
                table: "AccountBalances",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalance_Accounts_AccountId",
                table: "AccountBalances",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalances_Accounts_AccountId",
                table: "AccountBalances");

            migrationBuilder.DropIndex(
                name: "IX_AccountBalances_AccountId",
                table: "AccountBalances");
        }
    }
}
