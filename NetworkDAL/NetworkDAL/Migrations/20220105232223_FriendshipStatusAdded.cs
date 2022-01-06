using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class FriendshipStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "UsersFriends",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f7dc9c37-ac58-469d-a380-521b07790a21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "44c16a82-6f98-455e-b563-680c57405813");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09b3f0b3-8161-4bc2-9f65-89eb395d2512", "AQAAAAEAACcQAAAAEDBWqFwtosjs6vsR0fxRMjaIU99CTO2xgF0pfCCVEr9XomZi5/dakYQ6rTzzaYEoMw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "UsersFriends");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b5c72c2a-738a-415d-a864-125d30a0847a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bef425e2-0a3a-47ea-9f50-59bff3c052dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4a7fea8-80d1-4718-a830-d8ce95051ab3", "AQAAAAEAACcQAAAAEDwmQXtMxVjcBgfsc9OD/s+65L6OBtQzEPswgqueSZaJ1IE0G3mD5zQ5FWTC7yBeyQ==" });
        }
    }
}
