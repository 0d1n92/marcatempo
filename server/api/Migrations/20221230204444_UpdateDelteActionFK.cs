using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UpdateDelteActionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Giustifications_GiustificationId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_GiustificationId",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "GiustificationId",
                table: "Actions");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(125), "753085f7-0900-4b76-9ba3-5992c1e7605e" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(127), "b65edeef-01bb-4419-ba88-e89e4124a801" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(129), "75c59376-3d67-447c-adc2-50dcb47954c0" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(130), "84268cdf-8e13-4fe4-a938-5c0f050e1fe1" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(132), "f5e03bc7-306a-482c-9950-f099d911e8f0" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(134), "0ae939ae-1083-412a-9e91-5ed7e7e2d4c7" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 706, DateTimeKind.Local).AddTicks(135), "74373076-5485-4791-a09f-63afcd7f87df" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 43, 407, DateTimeKind.Local).AddTicks(6660), new DateTime(2022, 12, 30, 21, 44, 43, 407, DateTimeKind.Local).AddTicks(6707), "$2a$11$fbCDBRGE7WLFZQNk2raLk.JtXRLncrGB9dVHXwVUejXb12cLdYBTa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 43, 550, DateTimeKind.Local).AddTicks(8265), new DateTime(2022, 12, 30, 21, 44, 43, 550, DateTimeKind.Local).AddTicks(8325), "$2a$11$97njbg7zgrpoQCD/fGKqiOE6ddB3eqjH252qKTsdMFfltx5hZuI/i" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 43, 696, DateTimeKind.Local).AddTicks(2722), new DateTime(2022, 12, 30, 21, 44, 43, 696, DateTimeKind.Local).AddTicks(2755), "$2a$11$GJg7caCgdB3zJCy3h0.dque/q7Mo2ywhR842EgSUoh3LdPWh8MKnK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 43, 840, DateTimeKind.Local).AddTicks(1403), new DateTime(2022, 12, 30, 21, 44, 43, 840, DateTimeKind.Local).AddTicks(1503), "trevor_turner@romaguera.biz", "Jalyn", "Pfeffer", "$2a$11$hu32FSh2N3wx0cUD1/8IzO4ow3hxHbqYOfERlpk0abMWUmzLgS2K2", "kariane_deckow" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 43, 983, DateTimeKind.Local).AddTicks(7902), new DateTime(2022, 12, 30, 21, 44, 43, 983, DateTimeKind.Local).AddTicks(7918), "maeve_mccullough@goodwin.co.uk", "Vergie", "Parker", "$2a$11$7S6t81/FC/DBezMtl89jEOUK.1r4ZMbVhFowTMR7ikMq3eveun6nq", "issac" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 131, DateTimeKind.Local).AddTicks(3921), new DateTime(2022, 12, 30, 21, 44, 44, 131, DateTimeKind.Local).AddTicks(3940), "liliana@roberts.us", "Marina", "Ruecker", "$2a$11$TvtBwus8LoA4map/Quhr.OzIlQdMa6FfUYpIEXl6Q08BFPhh2wRLe", "teresa_conn" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 274, DateTimeKind.Local).AddTicks(8602), new DateTime(2022, 12, 30, 21, 44, 44, 274, DateTimeKind.Local).AddTicks(8617), "daron_marvin@hoegerhomenick.info", "Verona", "Streich", "$2a$11$UzEtKjshRmUvffdO2r7qEu6T1TurXLUVUkYEFwWwxyaDNIuco6Uou", "hester.beatty" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 418, DateTimeKind.Local).AddTicks(4377), new DateTime(2022, 12, 30, 21, 44, 44, 418, DateTimeKind.Local).AddTicks(4396), "eloisa@gibson.ca", "Pauline", "Kertzmann", "$2a$11$3lXF7kIQZqpLreOW4Edcl.IomnkIf7/9.1e52WPm3dhtZqFYclMWa", "elliott.hoppe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 561, DateTimeKind.Local).AddTicks(6507), new DateTime(2022, 12, 30, 21, 44, 44, 561, DateTimeKind.Local).AddTicks(6531), "zoie@mckenziestracke.name", "Lawrence", "Weissnat", "$2a$11$pjaPdU5.gO5SSnS0/7CyteDMTzDt1/tT/GFefNpac5jVAUOKGydC.", "corine" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 30, 21, 44, 44, 705, DateTimeKind.Local).AddTicks(9619), new DateTime(2022, 12, 30, 21, 44, 44, 705, DateTimeKind.Local).AddTicks(9638), "linnea@sengerhayes.ca", "Kaitlin", "Zieme", "$2a$11$unM.th9y16A/TLJWC2SnAe2V1i43EYZU9XJCHqE/PxAyqI8QEcbDq", "clotilde_swaniawski" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiustificationId",
                table: "Actions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6731), "3e0dd8df-124d-4aba-aaa6-acf65c5d5002" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6733), "36030900-f547-44f7-bcb8-ee96cf7143f3" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6735), "335a86dd-bc56-4e01-886d-6e34ba02bb44" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6737), "30727c24-b440-4dac-84df-0c18cc35c892" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6739), "78b64cd9-e5e0-43ba-ae02-63daf5d47551" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6752), "3ae397b8-61ee-4f10-894b-e44b93177b46" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6754), "7db3b2a2-c9f4-4a69-9cea-366573256a81" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 19, 183, DateTimeKind.Local).AddTicks(5505), new DateTime(2022, 8, 17, 1, 35, 19, 183, DateTimeKind.Local).AddTicks(5538), "$2a$11$qtjAq1EZNtpXGYJS2SnudeZlVDqnPVMSk6zhOH/z4cowLhlieFjKa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 19, 326, DateTimeKind.Local).AddTicks(7826), new DateTime(2022, 8, 17, 1, 35, 19, 326, DateTimeKind.Local).AddTicks(7881), "$2a$11$r6Nece1JqpKADBzaPhWzWusWW3K6tWUS6p6uzaj86gswMmhJK2AAW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 19, 471, DateTimeKind.Local).AddTicks(5522), new DateTime(2022, 8, 17, 1, 35, 19, 471, DateTimeKind.Local).AddTicks(5579), "$2a$11$ib32gCvuBavXY/J2995Q2Op5p2XsHiqZay/rQmRgLeHmCF7g2bj76" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 19, 615, DateTimeKind.Local).AddTicks(7385), new DateTime(2022, 8, 17, 1, 35, 19, 615, DateTimeKind.Local).AddTicks(7414), "keshaun@dickens.com", "Arnold", "Bogan", "$2a$11$QbBJigserDoJcEGMny4VNO0/08uwA6YloFd09ImJoVydR1FLzi6zK", "mckenzie" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 19, 757, DateTimeKind.Local).AddTicks(9274), new DateTime(2022, 8, 17, 1, 35, 19, 757, DateTimeKind.Local).AddTicks(9294), "domenick@beatty.info", "Craig", "Rempel", "$2a$11$AR0PPmXpDfxgVX5y8UxPO.jQhLW.uUMxuh7cY8jpRnXqXRH8g.t7i", "mellie.jewess" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 19, 901, DateTimeKind.Local).AddTicks(6410), new DateTime(2022, 8, 17, 1, 35, 19, 901, DateTimeKind.Local).AddTicks(6436), "rachelle@prohaska.info", "Annabelle", "Moen", "$2a$11$xkJ3CUJox6vuhijOPSdlQOHFr4VSBJ4pWTDnxGFPPLrhVLLQfL7RC", "cary_schmeler" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 49, DateTimeKind.Local).AddTicks(3416), new DateTime(2022, 8, 17, 1, 35, 20, 49, DateTimeKind.Local).AddTicks(3441), "haleigh@torphy.uk", "Edgar", "Hagenes", "$2a$11$D85xqaJAHrOXEZ77Kd.TgO7WPNk9N61ucJhMrUU85Ydgv3Hy6.2OG", "fermin.hermiston" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 191, DateTimeKind.Local).AddTicks(3980), new DateTime(2022, 8, 17, 1, 35, 20, 191, DateTimeKind.Local).AddTicks(4002), "araceli@johnstonterry.ca", "Alfonso", "West", "$2a$11$bRQxy1lqoyhISBHILuzkyut6ccPuwBFvFOgupOzVyZEKUjSaQihu6", "ivory.dickinson" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 333, DateTimeKind.Local).AddTicks(3570), new DateTime(2022, 8, 17, 1, 35, 20, 333, DateTimeKind.Local).AddTicks(3591), "elmer_beatty@strackelesch.ca", "Alexander", "Gusikowski", "$2a$11$cB2y73vs6p4wJtuyRfiyWujFqmz050eE0Z9Y9XnQSGwiisej96qcG", "kenyatta.goodwin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6385), new DateTime(2022, 8, 17, 1, 35, 20, 475, DateTimeKind.Local).AddTicks(6408), "laury.orn@schinnerweimann.us", "Otto", "Heidenreich", "$2a$11$ZYrBqLn3Z0cLRtQlVOyFMe4HZBCwII3e92GEGZXM44r8/vuDTOcd6", "marianne_mckenzie" });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_GiustificationId",
                table: "Actions",
                column: "GiustificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Giustifications_GiustificationId",
                table: "Actions",
                column: "GiustificationId",
                principalTable: "Giustifications",
                principalColumn: "Id");
        }
    }
}
