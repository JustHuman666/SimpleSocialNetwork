using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class PhoneNumberDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "aea218e9-d3c8-4480-91e9-87efdc8f99b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "98c8ffff-963a-466b-adff-9bbe74ff5284");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c3136a7f-7933-4031-986e-f3092d4495b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e80e0529-af60-42ae-a70c-8980ba06047d", "AQAAAAEAACcQAAAAEH8pN+HuoS+v4rEeomRMr163GjstDH/m9kkV44HXzQAjZZVfLR+3bL8QhcYKsWecaQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cb98c801-b4e0-4fd8-ba4d-0640de1b71b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e8e7ca38-55fa-4ab2-ae77-051128d0e07a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f3ae34cc-ac4e-4140-8af6-c7b62f2dc351");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5402c517-a9c5-4863-975f-d79ba40fb9e5", "AQAAAAEAACcQAAAAEBbwtjSXDi3O+hEKOGy6V76UaKxluIxMPGWRkhZGYUk9BKsXwW7tBrRhv6CTziDcog==" });
        }
    }
}
