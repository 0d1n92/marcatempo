using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: null,
                column: "Username",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1507), "d6485ed0-4b16-4f51-9f83-114350e5bcfb" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1509), "048326d2-7548-47d8-aef8-16845fba8689" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1510), "16a994d9-3355-4b8e-a5eb-bf0823d8a287" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1524), "f43ab6ae-9922-4366-922d-2ca88b659f89" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1526), "704ba4d6-9fe6-483b-a6ac-35047bebae57" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1528), "3c6d55fb-8782-4fef-a797-aeb6f97d8ffc" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1533), "a1ed8645-5167-48fd-a176-32af86b71901" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 74, DateTimeKind.Local).AddTicks(8204), new DateTime(2022, 7, 30, 13, 35, 35, 74, DateTimeKind.Local).AddTicks(8245), "admin@mail.com", "$2a$11$Zl/t2IrA9r9HzZ7Oex83Ounlj5N.ZoI3G4xegiTGK.xFDs/isq3Vi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 219, DateTimeKind.Local).AddTicks(7465), new DateTime(2022, 7, 30, 13, 35, 35, 219, DateTimeKind.Local).AddTicks(7528), "operator@mail.com", "$2a$11$t0jSlVLpmGZGOpau.e5Ftuxfigieyvkf.NhzNXeRr3WFjevhVR7vi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 364, DateTimeKind.Local).AddTicks(8857), new DateTime(2022, 7, 30, 13, 35, 35, 364, DateTimeKind.Local).AddTicks(8927), "pippo@mail.com", "$2a$11$DrXNXKqX2xTwHSrsC3wYg.D2UUJtATspauF2rxkMOQZ2UeU9aeNOW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 510, DateTimeKind.Local).AddTicks(6719), new DateTime(2022, 7, 30, 13, 35, 35, 510, DateTimeKind.Local).AddTicks(6741), "jolie.kovacek@stracke.biz", "Rhett", "Goyette", "$2a$11$XvkuB463MlUPzf9P1mmxtOibQQXn/gvslJQg1S7QVgpDFcV8Nre5K", "jordan.rath" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 661, DateTimeKind.Local).AddTicks(4430), new DateTime(2022, 7, 30, 13, 35, 35, 661, DateTimeKind.Local).AddTicks(4452), "torey@hintz.ca", "Julien", "Braun", "$2a$11$rRIC4ngfJxE0001kHAVs5uxpYjyiFgcKo8L6WFjrJptZo3RVCXUbe", "rosamond" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 805, DateTimeKind.Local).AddTicks(9354), new DateTime(2022, 7, 30, 13, 35, 35, 805, DateTimeKind.Local).AddTicks(9381), "garth@ryan.biz", "Bria", "Hettinger", "$2a$11$Blv6rLGFW2MsPa1snXNgxOq2pFd9PcwLzMwZnAtjKVZkPekse36d.", "karina.carroll" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 950, DateTimeKind.Local).AddTicks(5464), new DateTime(2022, 7, 30, 13, 35, 35, 950, DateTimeKind.Local).AddTicks(5483), "franco@ritchie.ca", "Harrison", "Lebsack", "$2a$11$WJ/TSFNslcWPC2hDjTErvu/UMomZ.76nmU2JuRzh07NS.j5lJo2gC", "sigrid_paucek" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 95, DateTimeKind.Local).AddTicks(1585), new DateTime(2022, 7, 30, 13, 35, 36, 95, DateTimeKind.Local).AddTicks(1609), "justine.hermiston@powlowskiwaters.co.uk", "Liana", "Harber", "$2a$11$nCpMT031hYjzeb4dRm44uO8jtoADLudP/cB.rxV3EeqqXpBahyapi", "leatha_windler" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 240, DateTimeKind.Local).AddTicks(1342), new DateTime(2022, 7, 30, 13, 35, 36, 240, DateTimeKind.Local).AddTicks(1370), "denis@langbauch.us", "Zula", "Shields", "$2a$11$KvZdWulca.WDqIa1yYU.Q.6ggZ68tnFX068J0eRlJ9RpGexK8XI3u", "frederik.mann" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1017), new DateTime(2022, 7, 30, 13, 35, 36, 385, DateTimeKind.Local).AddTicks(1041), "alf_grimes@hermiston.name", "Waino", "Bernhard", "$2a$11$COgQwUzERD3HxCFV.LIVx.eR.ZPnkEgH.8sNM.CFTlZ7GtmAZNvLS", "spencer_hilll" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6187), "7775286b-4123-4e89-ba8e-f59dec0deb2a" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6199), "dde23727-5cae-4cf0-8adf-3ee8238d33b1" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6201), "426b8696-84d2-45d2-91b7-eb4eccece2fc" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6203), "02dc24d8-5f53-4e4a-b1c7-5636b864e6c2" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6205), "0c49a450-b2ba-4024-ac97-3482de9618b8" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6207), "63b0a13c-6366-45ec-8586-119a384de033" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6208), "961c4a82-9a03-4211-8b9a-60d986f66398" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "Password" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 53, 117, DateTimeKind.Local).AddTicks(1687), new DateTime(2022, 7, 20, 23, 3, 53, 117, DateTimeKind.Local).AddTicks(1751), null, "$2a$11$Vq5U9P2BVI24IyGfdLpbWeULwZ/t2RejCPuMEvJYc5PINZ25THZF." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "Password" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 53, 265, DateTimeKind.Local).AddTicks(7100), new DateTime(2022, 7, 20, 23, 3, 53, 265, DateTimeKind.Local).AddTicks(7132), null, "$2a$11$S5/s/4kigUp7hmnf6fLlTuAhoV0aj9ZK3Au6avjEt/F4px0ac0WCm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "Password" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 53, 416, DateTimeKind.Local).AddTicks(9927), new DateTime(2022, 7, 20, 23, 3, 53, 417, DateTimeKind.Local).AddTicks(2), null, "$2a$11$KWAX85M0NVuntHi/N/2rfe6rW6JoAY/aZgXVV6/Z06JfF7EWrccju" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 53, 565, DateTimeKind.Local).AddTicks(5460), new DateTime(2022, 7, 20, 23, 3, 53, 565, DateTimeKind.Local).AddTicks(5491), null, "Hunter", "Schmidt", "$2a$11$0L/dgczJvXEQroRYYNrGIO8EYXLYDfuoLL2Irm4YKkSe9Bcq9eIty", "arielle" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 53, 717, DateTimeKind.Local).AddTicks(8320), new DateTime(2022, 7, 20, 23, 3, 53, 717, DateTimeKind.Local).AddTicks(8352), null, "Helene", "Hills", "$2a$11$RQmX726DCCUVPUTkmCJ1GuFaASBY5ICV2agbyn761teY6geQQaX5O", "ruben" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 53, 866, DateTimeKind.Local).AddTicks(4601), new DateTime(2022, 7, 20, 23, 3, 53, 866, DateTimeKind.Local).AddTicks(4629), null, "Unique", "Oberbrunner", "$2a$11$GuE7N9mrLYoTRRvj47Yoiexg3.Y9iJQEvpMchFvpZq5sxTC3HlZNG", "audrey.konopelski" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 15, DateTimeKind.Local).AddTicks(9638), new DateTime(2022, 7, 20, 23, 3, 54, 15, DateTimeKind.Local).AddTicks(9666), null, "Wiley", "Roob", "$2a$11$jKCS0CShf5QpjISrZ0QS9.ifnlGqG63a86XuhFvRY6Vc4B6JdnyCy", "elta" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 164, DateTimeKind.Local).AddTicks(5676), new DateTime(2022, 7, 20, 23, 3, 54, 164, DateTimeKind.Local).AddTicks(5704), null, "Elisha", "Stokes", "$2a$11$4MPrETWyC09jy8DlmTkseuIuaR1wIqPjxUVB.2FVjb18qomA9vg.e", "deborah" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 313, DateTimeKind.Local).AddTicks(2339), new DateTime(2022, 7, 20, 23, 3, 54, 313, DateTimeKind.Local).AddTicks(2368), null, "Jamel", "Ziemann", "$2a$11$IMeg3lyORLRggsdR6xrTEuvhbzLsSRcghnGLGq.08buyS08SFZuh.", "wava_reinger" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(5577), new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(5605), null, "Naomi", "Welch", "$2a$11$M.vwVLKPQI0wc3itBBq9luiQkEq3YT7JW4lnjpDyLznrcLOZar24u", "charlotte_stiedemann" });
        }
    }
}
