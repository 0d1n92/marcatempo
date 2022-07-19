using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class seedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 19, 18, 52, 45, 836, DateTimeKind.Local).AddTicks(3460), new DateTime(2022, 7, 19, 18, 52, 45, 836, DateTimeKind.Local).AddTicks(3507), "$2a$11$bR/9INoW88yucIPArTOX/.8HJvD5SgibLiZ9opWWvCjjxaCA9i/Y." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 19, 18, 52, 45, 979, DateTimeKind.Local).AddTicks(4685), new DateTime(2022, 7, 19, 18, 52, 45, 979, DateTimeKind.Local).AddTicks(4728), "$2a$11$rz9/6H/b3CC9L3S/9dmymOW5ifi/Fii3ByUXPUHUgy7v2/o/I6jJK" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "ModifyDate", "Password", "RoleId", "Token", "Username" },
                values: new object[] { 3, new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6082), new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6121), null, "Jonh", "Doe", null, "$2a$11$oqUmqD84exMH0zhk6bh/TOsNpKYU4aynT44nz68RMkVDrdCJCQIS6", 2, null, "Pippo" });

            migrationBuilder.InsertData(
                table: "QRcodes",
                columns: new[] { "Id", "CreationDate", "UpdateDate", "UserId", "token" },
                values: new object[] { 2, new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6444), null, 3, "lglglglgllglglglgllglglglgllglgglgllglglg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 10, 1, 25, 29, 175, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 10, 1, 25, 29, 31, DateTimeKind.Local).AddTicks(6436), new DateTime(2022, 7, 10, 1, 25, 29, 31, DateTimeKind.Local).AddTicks(6486), "$2a$11$e4AHqGd4M2fOBmVUvb4zBejOi3mD0BGMI.xiNT8GwwpnytXsHsd9e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 10, 1, 25, 29, 174, DateTimeKind.Local).AddTicks(9807), new DateTime(2022, 7, 10, 1, 25, 29, 174, DateTimeKind.Local).AddTicks(9850), "$2a$11$TY6W8TbakRViMg9Rm5ev0.poVHV9E8ra0VOOR4ZalCDmROOokiBRi" });
        }
    }
}
