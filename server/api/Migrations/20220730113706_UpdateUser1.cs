using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UpdateUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
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
                value: new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7480), "44e6c5e0-f2cb-4ba5-bf36-b991fdd58da0" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7482), "736289c5-60ce-488b-9787-4eb2a4fb6059" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7484), "856c2d80-ad33-44cd-86e1-0f62ff0ee0d4" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7486), "9b37cc2a-49ee-43af-90e1-65e93f3675a9" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7488), "795bec11-cc76-43b6-91ca-af26a84c4ec0" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7490), "8e8aa99b-087f-4130-b51b-533468961e0d" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7492), "d11cd38d-336c-4008-a20c-10540c13e71e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 4, 547, DateTimeKind.Local).AddTicks(526), new DateTime(2022, 7, 30, 13, 37, 4, 547, DateTimeKind.Local).AddTicks(565), "$2a$11$uNBPtjKJs6StvtCiDGt35ORja4IYYnj5eregWvgweZq6HRmnqRD5q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 4, 693, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 7, 30, 13, 37, 4, 693, DateTimeKind.Local).AddTicks(1721), "$2a$11$OHAUNcLiv41nLM765zqWhOxHwNh33WX7ferYnvqzWVbvn1ZQKVVQO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 4, 841, DateTimeKind.Local).AddTicks(1827), new DateTime(2022, 7, 30, 13, 37, 4, 841, DateTimeKind.Local).AddTicks(1896), "$2a$11$eG8k5VCUQddD7I5/Qwi6YepMhP19K6Gcx9/KVbU6bOvSBVBuxebdO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 4, 988, DateTimeKind.Local).AddTicks(7658), new DateTime(2022, 7, 30, 13, 37, 4, 988, DateTimeKind.Local).AddTicks(7679), "elenora@jast.com", "Edward", "Torphy", "$2a$11$rsvhtxvoRus2sN5Mm5s.KeMDIpj3cVoULSnx0ZvT0mj4R6wXGkcVK", "gina" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 142, DateTimeKind.Local).AddTicks(9576), new DateTime(2022, 7, 30, 13, 37, 5, 142, DateTimeKind.Local).AddTicks(9597), "forrest@nitzsche.name", "Damien", "Roberts", "$2a$11$bTIhcnIZVTjllnV/DbBzZejx1Mhpufw4N5Qfr6pPgwUZgLGWIK8py", "fern" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 292, DateTimeKind.Local).AddTicks(5834), new DateTime(2022, 7, 30, 13, 37, 5, 292, DateTimeKind.Local).AddTicks(5856), "connor_adams@vonruedenbeahan.info", "Garret", "Wisoky", "$2a$11$Nl6WW7.P01KYLkHQzdog2OF15NT9XXB1QUNSfTgyPQI8kPbtxT58i", "fredrick_shields" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 441, DateTimeKind.Local).AddTicks(1103), new DateTime(2022, 7, 30, 13, 37, 5, 441, DateTimeKind.Local).AddTicks(1125), "terrell.kulas@carter.ca", "Vinnie", "Bode", "$2a$11$AD2K8FIj8lyDMUHJapaf1.BC2I0jZnBle1Bm85leJJ.xa0oU9CjWG", "daphne" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 588, DateTimeKind.Local).AddTicks(5908), new DateTime(2022, 7, 30, 13, 37, 5, 588, DateTimeKind.Local).AddTicks(5924), "alford.vandervort@wilderman.info", "Rick", "Dach", "$2a$11$dniwHzuEsD4KoduDd0a9wO58fG1eihofxyOVekrq0sL3EVh3jWZzi", "bryana_reichel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 734, DateTimeKind.Local).AddTicks(9403), new DateTime(2022, 7, 30, 13, 37, 5, 734, DateTimeKind.Local).AddTicks(9420), "lawrence@nicolas.co.uk", "Russel", "Lynch", "$2a$11$Q8NYN56./s6F5aGgGnZp0.jlJwt9NjP2D5Ed/WkI9OjobQsCCiV.O", "demarcus" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7145), new DateTime(2022, 7, 30, 13, 37, 5, 880, DateTimeKind.Local).AddTicks(7170), "prince@littel.com", "Freda", "Mertz", "$2a$11$GSG0JCnOT.vSk8vAgWKM1uNe0oqvix8ebi8cgKlWtuWDC2myUw0um", "tamia_mitchell" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
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
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 74, DateTimeKind.Local).AddTicks(8204), new DateTime(2022, 7, 30, 13, 35, 35, 74, DateTimeKind.Local).AddTicks(8245), "$2a$11$Zl/t2IrA9r9HzZ7Oex83Ounlj5N.ZoI3G4xegiTGK.xFDs/isq3Vi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 219, DateTimeKind.Local).AddTicks(7465), new DateTime(2022, 7, 30, 13, 35, 35, 219, DateTimeKind.Local).AddTicks(7528), "$2a$11$t0jSlVLpmGZGOpau.e5Ftuxfigieyvkf.NhzNXeRr3WFjevhVR7vi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 30, 13, 35, 35, 364, DateTimeKind.Local).AddTicks(8857), new DateTime(2022, 7, 30, 13, 35, 35, 364, DateTimeKind.Local).AddTicks(8927), "$2a$11$DrXNXKqX2xTwHSrsC3wYg.D2UUJtATspauF2rxkMOQZ2UeU9aeNOW" });

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
    }
}
