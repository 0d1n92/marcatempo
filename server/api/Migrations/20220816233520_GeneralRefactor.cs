using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class GeneralRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "metaLabel",
                table: "UserMetas",
                newName: "Metalabel");

            migrationBuilder.RenameColumn(
                name: "token",
                table: "QRcodes",
                newName: "Token");

            migrationBuilder.RenameIndex(
                name: "IX_QRcodes_token",
                table: "QRcodes",
                newName: "IX_QRcodes_Token");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "Giustifications",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Giustifications",
                newName: "Code");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Metalabel",
                table: "UserMetas",
                newName: "metaLabel");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "QRcodes",
                newName: "token");

            migrationBuilder.RenameIndex(
                name: "IX_QRcodes_Token",
                table: "QRcodes",
                newName: "IX_QRcodes_token");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Giustifications",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Giustifications",
                newName: "code");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2307), "b936fb76-2be4-4423-8299-c7e084e75a9c" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2309), "4bfa4dda-356e-460a-b03f-71850d69eabc" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2321), "29088189-957f-4a6b-887b-818e879dfe0e" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2323), "a36d8ed2-1b34-476d-aa4b-185995c92f44" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2325), "72fa217e-d3e6-4614-afea-be2e9abb84e7" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2327), "2d715fe2-4a53-4c04-a595-c29a87e9bd9e" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(2328), "6919b7a9-e5e6-4871-9bf8-38c33329ed69" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 39, 938, DateTimeKind.Local).AddTicks(5044), new DateTime(2022, 8, 6, 17, 32, 39, 938, DateTimeKind.Local).AddTicks(5078), "$2a$11$e/16/tKRGgcNXRoo8McLyedGIUXmCzRyzu4SF45y5a4cUv/5j54qq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 80, DateTimeKind.Local).AddTicks(3580), new DateTime(2022, 8, 6, 17, 32, 40, 80, DateTimeKind.Local).AddTicks(3644), "$2a$11$w8Aaj5kmzqjtQT.1F3k0HOCivEpGis8maBYXtevzOmvaC..B7Us1u" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 224, DateTimeKind.Local).AddTicks(1415), new DateTime(2022, 8, 6, 17, 32, 40, 224, DateTimeKind.Local).AddTicks(1446), "$2a$11$U045xWyqFkCLaxtuPAa1ROeXR7ODlNm47J8Jvil23E7JNSjeBK3yO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 368, DateTimeKind.Local).AddTicks(3593), new DateTime(2022, 8, 6, 17, 32, 40, 368, DateTimeKind.Local).AddTicks(3651), "chester_murphy@wolffconn.us", "Emma", "Johnston", "$2a$11$W2UMOADMBR.O5dWM/ixceOaYSG0Y7jlOfqLpdHcNhDb9XKj8/k0j2", "logan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 511, DateTimeKind.Local).AddTicks(245), new DateTime(2022, 8, 6, 17, 32, 40, 511, DateTimeKind.Local).AddTicks(264), "frank.block@braun.ca", "Darren", "Becker", "$2a$11$1FCMIKL1Vl.dwJkObcukNuEjp.X6ggFKr0Io4z/ZSagm4Tt/otYj2", "zion_leuschke" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 652, DateTimeKind.Local).AddTicks(9299), new DateTime(2022, 8, 6, 17, 32, 40, 652, DateTimeKind.Local).AddTicks(9319), "claudie@collins.ca", "Karlee", "Rogahn", "$2a$11$kLFRcKVdutm8WRVqUcxxkO7IqzsM/W448eETMMZ3Msts3vNzrHmLu", "leonard_maggio" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 800, DateTimeKind.Local).AddTicks(3831), new DateTime(2022, 8, 6, 17, 32, 40, 800, DateTimeKind.Local).AddTicks(3852), "morgan@erdman.com", "Janice", "Botsford", "$2a$11$Hp44skb3LcsyaXZBRTLX6eiL6XAegppQJgR0l/kmaYxhOQj2/MfXy", "harry.kuhn" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 40, 942, DateTimeKind.Local).AddTicks(3083), new DateTime(2022, 8, 6, 17, 32, 40, 942, DateTimeKind.Local).AddTicks(3104), "yasmeen@sauerwhite.info", "Otha", "Turner", "$2a$11$vlGqf4Yw/sgHojiKHT5jL..idXY0CrNgR/nMvtvFuSr/By0utGkYq", "pink" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 84, DateTimeKind.Local).AddTicks(997), new DateTime(2022, 8, 6, 17, 32, 41, 84, DateTimeKind.Local).AddTicks(1016), "barry@collier.biz", "Ibrahim", "Rice", "$2a$11$AtE7WWwKrTywD9c4PCbw8eUstdWf0qjXoSHWOo/R1FymTvXJG8Z/q", "aryanna" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(1931), new DateTime(2022, 8, 6, 17, 32, 41, 226, DateTimeKind.Local).AddTicks(1956), "elisha@block.co.uk", "Flavie", "Hirthe", "$2a$11$3XTeu.1XaJyZiudlcVJJ.uw2brkzLlpb26IlHq5wqxGF4SDFfF6m2", "rusty.yundt" });
        }
    }
}
