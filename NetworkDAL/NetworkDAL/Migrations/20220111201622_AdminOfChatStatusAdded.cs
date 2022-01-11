using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class AdminOfChatStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_Chats_ChatId",
                table: "UsersChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_UserProfiles_UserId",
                table: "UsersChats");

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "UsersChats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3d2212a4-2f9b-4a9c-a780-15f5fbb2b569");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d0b67312-441a-4fba-a388-0c86596dc428");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf7de1e1-758a-42c2-8d4a-69e6c089d572", "AQAAAAEAACcQAAAAEF4Y51ERLmSxEJ9IZmrFbtZWhozGgFQcYATWNRyDlh5fCsb4PKsPP/jzw9fiThy8Cg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2df89de-a3c4-48b6-9afd-dd9bef369b47", "AQAAAAEAACcQAAAAELdBdmiPkTOJrlkJU25IIawhaRzWkWBm0/YVpPRtii1kfePjPQTpVAH62FeOYSFVnA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChats_Chats_ChatId",
                table: "UsersChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChats_UserProfiles_UserId",
                table: "UsersChats",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_Chats_ChatId",
                table: "UsersChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_UserProfiles_UserId",
                table: "UsersChats");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "UsersChats");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "eb92742a-307b-4f58-bc24-5c4fab1a1c20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0a14ed22-ab6a-4c17-bc09-f0f1d4f36cab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1bdbf6a2-a75f-4b4c-a293-d34fc6efac74", "AQAAAAEAACcQAAAAEMkeEutElIDLCmFNZZappZqE7KOWMCUb8nkI4jOG45xCTqoC5a5tTT8DwPXM7LnO+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "463b67e1-8e8d-4987-bbb9-ef58cec30e10", "AQAAAAEAACcQAAAAEMJaR43tSqHWdmV142cNdTdK+HlL+eE0bLhL/zfPFtMv69MluoHU61eRQXHqnZrDKQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChats_Chats_ChatId",
                table: "UsersChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChats_UserProfiles_UserId",
                table: "UsersChats",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
