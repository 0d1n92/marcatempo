using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UpdUserOncascateActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Users_UserId",
                table: "Actions");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7068), "5157e300-7181-4a23-81ac-33c36f5a003d" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7070), "2f5604ca-b63a-48fd-8796-45dcb0e27a54" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7072), "dfad9ed0-a375-45ad-956b-f44f7d401f42" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7074), "1e6bb8ff-98ec-4d1c-96e3-0dd48fa6745f" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7090), "50501ee0-2e23-441f-ba21-02c8f13b90d2" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7092), "7beb4bb7-8c5b-4b2b-aefd-a51155dbda32" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(7094), "a3ca7c38-b754-4b66-bfb7-59915796b405" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 54, 666, DateTimeKind.Local).AddTicks(7725), new DateTime(2024, 4, 4, 12, 31, 54, 666, DateTimeKind.Local).AddTicks(7772) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 54, 810, DateTimeKind.Local).AddTicks(2662), new DateTime(2024, 4, 4, 12, 31, 54, 810, DateTimeKind.Local).AddTicks(2719), "$2a$11$cLQkDN/QIB5Wb9hKP5EFwOpMLVwW0QH3d.BfERT/BwOVu.00/nKQO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 54, 954, DateTimeKind.Local).AddTicks(6617), new DateTime(2024, 4, 4, 12, 31, 54, 954, DateTimeKind.Local).AddTicks(6678), "$2a$11$U.KCDLqhEmMgKaU7.e/uPuUrGQJevkHbaBXBjhO8SZK7plFNhfc4q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 99, DateTimeKind.Local).AddTicks(4004), new DateTime(2024, 4, 4, 12, 31, 55, 99, DateTimeKind.Local).AddTicks(4032), "russel@howell.us", "Lilyan", "Towne", "$2a$11$p4IsE5UJUtI.MXXUodtLTOurvKJv/pemaCLg6n25Bxc7WhgdkntXm", "schuyler" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 243, DateTimeKind.Local).AddTicks(5429), new DateTime(2024, 4, 4, 12, 31, 55, 243, DateTimeKind.Local).AddTicks(5568), "allan@pouros.name", "Maybell", "Wiza", "$2a$11$uY/HboDoTsScNYila.DpSuI7kL3FTrEj1E6HKoTfEvcwVRZ5tVR6y", "garry_swaniawski" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 388, DateTimeKind.Local).AddTicks(6294), new DateTime(2024, 4, 4, 12, 31, 55, 388, DateTimeKind.Local).AddTicks(6320), "kailyn_jewess@crona.name", "Lexie", "Hirthe", "$2a$11$oyCV1oeP/4cx0WZEZE3pzuoZQ/eP7YpIytuFWo0vkeQoMqSSMkMFS", "lee_reichel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 534, DateTimeKind.Local).AddTicks(703), new DateTime(2024, 4, 4, 12, 31, 55, 534, DateTimeKind.Local).AddTicks(723), "oral@dietrich.biz", "Lambert", "Zulauf", "$2a$11$hNHhzjtOCXuGwpQG3YQK.OJStPOC4x96by09l6J1LCk/9BKaaPe/6", "jarret_stanton" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 677, DateTimeKind.Local).AddTicks(3144), new DateTime(2024, 4, 4, 12, 31, 55, 677, DateTimeKind.Local).AddTicks(3162), "dock@moen.co.uk", "Alverta", "Lubowitz", "$2a$11$vogFcvt2ATSZSI2s/a12pOVwIWuXDGGkgYxq0cwRyC1Z4CLrsvOxy", "phoebe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 820, DateTimeKind.Local).AddTicks(8410), new DateTime(2024, 4, 4, 12, 31, 55, 820, DateTimeKind.Local).AddTicks(8430), "jerad@macejkovic.info", "Meredith", "Deckow", "$2a$11$bG2Rt76LuQHJtH/mij.NM.gA0mPmbEkNupCiYu5./tNWYSz0Qgqwu", "marietta_emmerich" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(6652), new DateTime(2024, 4, 4, 12, 31, 55, 964, DateTimeKind.Local).AddTicks(6671), "dorthy.volkman@blick.ca", "Parker", "Walsh", "$2a$11$zhKpKIHrw4Z60l.RO2Agsea7oiZyC4XQwHnoKnnpwuVlNuTER5YRm", "joan" });

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Users_UserId",
                table: "Actions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Users_UserId",
                table: "Actions");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4470), "ffef9801-1862-41e3-adab-612df6d0c157" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4471), "21b667a7-abdd-4b8e-bdf6-e2a691ba589e" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4473), "2c7c080f-68fe-4f7b-a33b-8455dc88f991" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4475), "ddb8c653-8f71-4815-ade2-27be679cb645" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4484), "b2e6efb5-2c02-460d-b3d8-502bb6fc0bdb" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4486), "91db2bc0-c19f-4304-852a-7ff425fb5314" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "Token" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4493), "c147ec91-367d-4c9c-88ee-21f10390e3fa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 2, 627, DateTimeKind.Local).AddTicks(817), new DateTime(2024, 3, 24, 11, 15, 2, 627, DateTimeKind.Local).AddTicks(868) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 2, 773, DateTimeKind.Local).AddTicks(9718), new DateTime(2024, 3, 24, 11, 15, 2, 773, DateTimeKind.Local).AddTicks(9764), "$2a$11$00ULs4den20SRAIF0mBg1u7tEq2fUn8PGiqIvUVBIFmfh4E8VI0JW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 2, 921, DateTimeKind.Local).AddTicks(4507), new DateTime(2024, 3, 24, 11, 15, 2, 921, DateTimeKind.Local).AddTicks(4579), "$2a$11$oVwZ4LkLB29T8M/PuqCYyeV8wt5rmZM8eQ3QjVU0AGr9nr3g859UO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 68, DateTimeKind.Local).AddTicks(8406), new DateTime(2024, 3, 24, 11, 15, 3, 68, DateTimeKind.Local).AddTicks(8436), "beatrice_borer@kuhn.biz", "Armani", "Feest", "$2a$11$FJ2E1ND8SnKwzJdlzP4bc.rPrIdhrMvgaYCSBXPdEjJ5JnaJBq8DW", "amanda" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 215, DateTimeKind.Local).AddTicks(9708), new DateTime(2024, 3, 24, 11, 15, 3, 215, DateTimeKind.Local).AddTicks(9880), "leola@nicolas.us", "Nikko", "Lehner", "$2a$11$HX4knnYK0NibNadeTXwx4.KpAOMI0zCY1xrIA.TAd6Q./1lXxabmi", "carissa_flatley" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 362, DateTimeKind.Local).AddTicks(8152), new DateTime(2024, 3, 24, 11, 15, 3, 362, DateTimeKind.Local).AddTicks(8178), "jack@sauervonrueden.com", "Delia", "Keebler", "$2a$11$p0FkS4m56dHpL1sZlIrtSO66H75nQSYcUBEvayOu2AmruFwLbKw3e", "dianna.funk" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 511, DateTimeKind.Local).AddTicks(6950), new DateTime(2024, 3, 24, 11, 15, 3, 511, DateTimeKind.Local).AddTicks(6973), "sibyl@schaefermarquardt.co.uk", "Ila", "O'Kon", "$2a$11$ooIhR2LOKajjC1udIv.WHOY4EzZI1dAPmBwoWuhmnbg5lgSgBYvA.", "houston" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 662, DateTimeKind.Local).AddTicks(3363), new DateTime(2024, 3, 24, 11, 15, 3, 662, DateTimeKind.Local).AddTicks(3385), "mayra@kuhicbechtelar.com", "Lesley", "Dare", "$2a$11$VkRs0yTkWBqqGScQBHX6H.BzHWnVIpD2n3EouJw9MosOX.DVcpTxe", "zoey" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 811, DateTimeKind.Local).AddTicks(1796), new DateTime(2024, 3, 24, 11, 15, 3, 811, DateTimeKind.Local).AddTicks(1819), "uriel@gleichner.co.uk", "Ramona", "Schaefer", "$2a$11$vfNlsms92vJuWMmqqSrwr.BAk/whitWdtBi5XsbjkBFANhmIZdkBC", "norbert" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4015), new DateTime(2024, 3, 24, 11, 15, 3, 956, DateTimeKind.Local).AddTicks(4033), "lowell_cummerata@streich.name", "Jaren", "Jaskolski", "$2a$11$uggOX6uCzfh.7JO2MU1tYefJxlW0mD/0cnXdj7L34cXPu64Yu6qL.", "clementine.goldner" });

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Users_UserId",
                table: "Actions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
