using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class CountryPropDeletedFromUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "065275c8-e8a3-41be-9ce8-265905656d37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "80c285c0-0230-46f1-8134-983058565339");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e63b70a9-6537-45da-b89c-a509599fa66b", "AQAAAAEAACcQAAAAELVtxqMwzDo69AYH9DI63R3ztQ6gTNXqG01eI9Si6ABqB+Cd28tM4WA1ycooti9okg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c011f44-c377-4c34-979c-4389f6fdd7da", "AQAAAAEAACcQAAAAEAO2tIoFzblmkRKLtoZ4B8CFYTdmUb9mCf/7PYc/ASB6djjLfHiOZSp6egUPawLi9A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d32d077f-847d-4a67-957a-47feb70927f0", "AQAAAAEAACcQAAAAEBWIMOm3zlcOJzKkaDoMk7co6dqnzr1Detr2yZtI1E3pb+tFueP2Dq6ovrvIP3K8ew==" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Country",
                value: "Ukraine");
        }
    }
}
