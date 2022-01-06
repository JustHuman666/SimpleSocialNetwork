using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class NewUserAddedToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8977e5f2-74ba-4a3b-883a-fb7fd05b8272");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "cbc63fba-2646-4d20-916a-a67107421c55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d1643bb6-4eb4-45a5-b1a3-c1cff6ecf82c", "AQAAAAEAACcQAAAAEPfWSwtRdC8FSXhL2LNtSClXQTL1udwcXp95oy6t+gHxXnUi+8a1SUJXjS77eIbvLQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "d32d077f-847d-4a67-957a-47feb70927f0", "default@gmail.com", false, false, null, "DEFAULT@GMAIL.COM", "DEFAULT", "AQAAAAEAACcQAAAAEBWIMOm3zlcOJzKkaDoMk7co6dqnzr1Detr2yZtI1E3pb+tFueP2Dq6ovrvIP3K8ew==", "+380000000000", false, null, false, "Default" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Country", "FirstName", "LastName" },
                values: new object[] { 1, "Ukraine", "Eleonora", "Mykhalchuk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Country", "FirstName", "LastName" },
                values: new object[] { 2, "Ukraine", "DefaultName", "DefaultLast" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
