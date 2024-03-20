using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class loginAttempts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginAttempts",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1417), "02fbaf49-3470-443d-928c-092007b4f1ae" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1419), "4eb648b3-bc09-4742-b01e-ccf78ed69839" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1421), "36c0e3c4-235d-44fc-b7d0-b6c165957375" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1423), "010cadcb-8fd3-4872-acfd-5fcac7018e55" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1425), "a780671c-3855-42b6-8088-a12efb6228d8" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1427), "5fa2e984-3c85-461a-85f2-47434d1e68f6" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(1428), "aabc185f-ef4d-49d6-a138-f7820f253449" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 9, 762, DateTimeKind.Local).AddTicks(5455), new DateTime(2024, 3, 19, 15, 37, 9, 762, DateTimeKind.Local).AddTicks(5509), "$2a$11$OQGFpkeJiBiv.NPJNbGmweNhMUGXgopMWQKa0AMVUDQMgVkhlA85m" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 9, 909, DateTimeKind.Local).AddTicks(4185), new DateTime(2024, 3, 19, 15, 37, 9, 909, DateTimeKind.Local).AddTicks(4227), "$2a$11$dZ1PPWuYaKBOjt7RCFv/ieZuzlXQaAMv4zwdlRXsLVHIfI1FI0s0C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 56, DateTimeKind.Local).AddTicks(5105), new DateTime(2024, 3, 19, 15, 37, 10, 56, DateTimeKind.Local).AddTicks(5167), "$2a$11$2M60daQ8FTtBe9j53748DutnNBYZEPkFh.wPW4ncUW41Uy1ptZ2yG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 203, DateTimeKind.Local).AddTicks(1098), new DateTime(2024, 3, 19, 15, 37, 10, 203, DateTimeKind.Local).AddTicks(1173), "ursula_stark@medhursttromp.us", "Riley", "Ward", "$2a$11$t6/6lBmbvLwTWNYW4I3AH.rBfJ5N8lfEDH/q06dGlbT.Mjy0wQ65a", "george.thiel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 347, DateTimeKind.Local).AddTicks(9833), new DateTime(2024, 3, 19, 15, 37, 10, 347, DateTimeKind.Local).AddTicks(9853), "alexandrine@cummings.info", "Brenna", "Skiles", "$2a$11$0yzsW4/i1FX0ZqS24ra6Fexo.pZSCerRQ6lvgvx.8MX8pSxnhIR0G", "kristoffer" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 493, DateTimeKind.Local).AddTicks(6843), new DateTime(2024, 3, 19, 15, 37, 10, 493, DateTimeKind.Local).AddTicks(6864), "chloe@mcclure.uk", "Zelda", "Terry", "$2a$11$CUt3EM6u37LBBZ4dxEUsq.NHL2GqHKDnbzsrQNSqdXP5w9Mcn4G/y", "keely_kling" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 640, DateTimeKind.Local).AddTicks(9590), new DateTime(2024, 3, 19, 15, 37, 10, 640, DateTimeKind.Local).AddTicks(9610), "brenden_dickens@hintz.uk", "Marta", "Stanton", "$2a$11$2T/YSIBjMqdaf6Bczj/q/./DDOcdemfxMiHS120oFtIdM6tfPVuqi", "stefan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 785, DateTimeKind.Local).AddTicks(9111), new DateTime(2024, 3, 19, 15, 37, 10, 785, DateTimeKind.Local).AddTicks(9133), "troy@smith.info", "Yasmin", "Ullrich", "$2a$11$1c/9vxuuWHoBXxBA76J2EOxl3Rs1J/k3KV3ISwBkgKgqfPpcJUU62", "maurine" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 10, 932, DateTimeKind.Local).AddTicks(103), new DateTime(2024, 3, 19, 15, 37, 10, 932, DateTimeKind.Local).AddTicks(122), "jacques@carroll.uk", "Omer", "Bernhard", "$2a$11$tNckGDIvmBVPrUvamkGJvu0Tk/lXauR3fvxq7h8/T53OgEesbgoeq", "victor" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(917), new DateTime(2024, 3, 19, 15, 37, 11, 81, DateTimeKind.Local).AddTicks(937), "stephany.langosh@dooley.biz", "Reuben", "Schiller", "$2a$11$8ALpWrikFBz9QW/QTYDl..c7mApmhw2a6TK15Ik.q5xNCqfqE4Hsa", "stacy.herzog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginAttempts",
                table: "Users");

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
    }
}
