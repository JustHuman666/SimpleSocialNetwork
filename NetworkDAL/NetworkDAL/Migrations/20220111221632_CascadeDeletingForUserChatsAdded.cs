using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class CascadeDeletingForUserChatsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_Chats_ChatId",
                table: "UsersChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_UserProfiles_UserId",
                table: "UsersChats");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ddc80662-77ca-4af7-bda5-17e65581c9f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "064d0bdd-5bd7-46f9-a2ef-044ee7a9307b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b196297-c8ec-4442-8ee4-d3aedaa21115", "AQAAAAEAACcQAAAAEEWfpQf/moNPj7bD9iKVT1Wjmc6uqkyrV/Qv8+8SZMIUIePy4oi1wtpccl6W/MAw0A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c417890c-0423-4524-bb01-576dd9edb5fe", "AQAAAAEAACcQAAAAEHHh6nCDkjf8+Hj8W5E7UjKRSi8xjKethV1Tp96C6yAyi/P8XQLJhOCVLair2T5ANA==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_Chats_ChatId",
                table: "UsersChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChats_UserProfiles_UserId",
                table: "UsersChats");

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
    }
}
