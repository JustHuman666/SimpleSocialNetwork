using Microsoft.EntityFrameworkCore.Migrations;

namespace NetworkDAL.Migrations
{
    public partial class MessageStatusesDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageStatuses_StatusId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MessageStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Messages_StatusId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Messages");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8c7efd6d-f5ba-4934-a2ef-e4e3cbfabb57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "dac529d0-fabf-460b-b3b7-04a67c668c61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19e62b36-f752-4000-aac2-14a7016aed56", "AQAAAAEAACcQAAAAEKwxrfCg0V4yGyoq+x4BnhL3hN3tVDWN75uM7TrPnVt+qZCQGTQnTVe+/Cc+6pStXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7cb1bf96-415c-45fd-a778-283db26ccfa4", "AQAAAAEAACcQAAAAECKpH4zAuhluroFXOp1mvk2YSpeji3ZiNskE5NoiunQrOAHuhAO9MgeV9tpdccJD+A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MessageStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStatuses", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "MessageStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Sent" },
                    { 2, "Seen" },
                    { 3, "OnWay" },
                    { 4, "Error" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StatusId",
                table: "Messages",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageStatuses_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "MessageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
