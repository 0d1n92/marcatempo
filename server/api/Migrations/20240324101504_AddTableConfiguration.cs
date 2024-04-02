using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AddTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MetaName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Configuration",
                columns: new[] { "Id", "Category", "Description", "MetaName", "Value" },
                values: new object[] { 1, "mail", "server stmp", "mail_stmp_server", "{\"Server\":\"sandbox.smtp.mailtrap.io\",\"UserName\":\"de35ddf5383c06\",\"Port\":587,\"SenderEmail\":\"dev@marcatempo.it\",\"SenderName\":\"dev marcatempo\",\"Password\":\"ff133f4a7a43aa\"}" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_MetaName",
                table: "Configuration",
                column: "MetaName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");

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
                columns: new[] { "CreationDate", "DateOfBirth" },
                values: new object[] { new DateTime(2024, 3, 19, 15, 37, 9, 762, DateTimeKind.Local).AddTicks(5455), new DateTime(2024, 3, 19, 15, 37, 9, 762, DateTimeKind.Local).AddTicks(5509) });

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
    }
}
