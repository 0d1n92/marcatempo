using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class seedUserFaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 19, 19, 42, 53, 555, DateTimeKind.Local).AddTicks(6519), new DateTime(2022, 7, 19, 19, 42, 53, 555, DateTimeKind.Local).AddTicks(6585), "$2a$11$nDSmsG.K6tUHMQTTxeMJTOU4FMgquMb/.ejzT1N/xqq6C1Cu0jHTe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 19, 19, 42, 53, 699, DateTimeKind.Local).AddTicks(8901), new DateTime(2022, 7, 19, 19, 42, 53, 699, DateTimeKind.Local).AddTicks(8932), "$2a$11$TFlcJKT7/7iOBq1J0cM3weo0FhqHHMwF3CBj.54ECWCoMLS48e0hW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 19, 19, 42, 53, 845, DateTimeKind.Local).AddTicks(7113), new DateTime(2022, 7, 19, 19, 42, 53, 845, DateTimeKind.Local).AddTicks(7174), "$2a$11$jRlrhXFg7TNCyIH1Hfdczum7Ob6ZCb07J2i65HlqVrOK/NKx6eN1a" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "ModifyDate", "Password", "RoleId", "Token", "Username" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 7, 19, 19, 42, 53, 990, DateTimeKind.Local).AddTicks(2708), new DateTime(2022, 7, 19, 19, 42, 53, 990, DateTimeKind.Local).AddTicks(2730), null, "Mathias", "Sporer", null, "$2a$11$xOpNiN0p..VjIvNoUY/s7usg0JGsiQXSch9J7A8lyt8Y0sGOY6czC", 2, null, "berenice_morar" },
                    { 5, new DateTime(2022, 7, 19, 19, 42, 54, 134, DateTimeKind.Local).AddTicks(8755), new DateTime(2022, 7, 19, 19, 42, 54, 134, DateTimeKind.Local).AddTicks(8840), null, "Joan", "Romaguera", null, "$2a$11$Gn8UanurBSpvkxGugoTnSOsLF.ZL.nyO4WnGXxdIGxkHmEuMMpYj.", 2, null, "christa.thiel" },
                    { 6, new DateTime(2022, 7, 19, 19, 42, 54, 278, DateTimeKind.Local).AddTicks(9657), new DateTime(2022, 7, 19, 19, 42, 54, 278, DateTimeKind.Local).AddTicks(9684), null, "Angie", "Ledner", null, "$2a$11$0H7tJ1PxSn0G6XDjQs63vOgHLrfuocZehsVnHXAYdA0kmoc7H6pFK", 2, null, "earlene" },
                    { 7, new DateTime(2022, 7, 19, 19, 42, 54, 423, DateTimeKind.Local).AddTicks(1409), new DateTime(2022, 7, 19, 19, 42, 54, 423, DateTimeKind.Local).AddTicks(1431), null, "Joana", "Mosciski", null, "$2a$11$rw6av3y4nbnZnK4j3iZkIO/HQJaNU/1.IZAU7uUC.d3OwT0MvQUJ.", 2, null, "curt" },
                    { 8, new DateTime(2022, 7, 19, 19, 42, 54, 567, DateTimeKind.Local).AddTicks(1657), new DateTime(2022, 7, 19, 19, 42, 54, 567, DateTimeKind.Local).AddTicks(1688), null, "Shea", "Marks", null, "$2a$11$aKZ4/eBByaaEqw76ekuSTO7keD9VpHg0GGLwSaTSzQGdMPRE3spti", 2, null, "diana.bernhard" },
                    { 9, new DateTime(2022, 7, 19, 19, 42, 54, 711, DateTimeKind.Local).AddTicks(3834), new DateTime(2022, 7, 19, 19, 42, 54, 711, DateTimeKind.Local).AddTicks(3861), null, "Lambert", "Hackett", null, "$2a$11$J9Be8mg9c9S/69CVq1QLdeU.g6splrYY5Ljwb/0.WzIPXdy5UMd4a", 2, null, "saul_swaniawski" },
                    { 10, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(8330), new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(8357), null, "Liliana", "Wintheiser", null, "$2a$11$U68wPCJGK5A3HkIfD6lQy.yk04QWejN/6jnYIt2EMSQOhieFWFGFG", 2, null, "stephany.lakin" }
                });

            migrationBuilder.InsertData(
                table: "QRcodes",
                columns: new[] { "Id", "CreationDate", "UpdateDate", "UserId", "token" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9199), null, 4, "HH750941C" },
                    { 4, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9228), null, 5, "ZW019737B" },
                    { 5, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9249), null, 6, "JC579856C" },
                    { 6, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9270), null, 7, "OK323404A" },
                    { 7, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9322), null, 8, "SW352052D" },
                    { 8, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9344), null, 9, "LN078983D" },
                    { 9, new DateTime(2022, 7, 19, 19, 42, 54, 857, DateTimeKind.Local).AddTicks(9366), null, 10, "LB940954B" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6444));

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6082), new DateTime(2022, 7, 19, 18, 52, 46, 122, DateTimeKind.Local).AddTicks(6121), "$2a$11$oqUmqD84exMH0zhk6bh/TOsNpKYU4aynT44nz68RMkVDrdCJCQIS6" });
        }
    }
}
