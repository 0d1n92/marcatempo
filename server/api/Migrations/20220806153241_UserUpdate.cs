using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMetas_Users_UserId",
                table: "UserMetas");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserMetas_Users_UserId",
                table: "UserMetas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMetas_Users_UserId",
                table: "UserMetas");

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7451), "860b05e5-a462-4660-a438-18ab536c2bee" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7453), "15794b8a-be18-4c51-8c6a-4eb2d066da01" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7455), "11e2ba74-2038-4044-b121-63248df0d048" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7457), "f04e7c53-d221-4523-be89-8da0efd774c3" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7459), "d8fcec27-a178-4164-bbc5-398232b207c1" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7460), "3c790b7c-e480-4150-b9ac-7968b1f9dc88" });

            migrationBuilder.UpdateData(
                table: "QRcodes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "token" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7467), "a18f0984-1cde-4ba5-9366-3aa14c8ed3ca" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 13, 902, DateTimeKind.Local).AddTicks(8235), new DateTime(2022, 7, 31, 1, 15, 13, 902, DateTimeKind.Local).AddTicks(8280), "$2a$11$T37BPZdYjcRe2QyRXM27h.F.3JXTNUV43vcrvBUBuR2oKBzGefzY2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 50, DateTimeKind.Local).AddTicks(9688), new DateTime(2022, 7, 31, 1, 15, 14, 50, DateTimeKind.Local).AddTicks(9761), "$2a$11$j00A22I1jZGgSnHer.k.BOMPzGUsByj35cDX7v7HsGjWLssJPXnwi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 199, DateTimeKind.Local).AddTicks(6678), new DateTime(2022, 7, 31, 1, 15, 14, 199, DateTimeKind.Local).AddTicks(6770), "$2a$11$avPxGVtMx66uU8siqLHrK.08BfzaMsUvP1.sa4wmpF8PAZsafEXlm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 347, DateTimeKind.Local).AddTicks(9860), new DateTime(2022, 7, 31, 1, 15, 14, 347, DateTimeKind.Local).AddTicks(9879), "destinee_rowe@morarkeeling.uk", "Maia", "Hermiston", "$2a$11$8prUH2./1w5osWcfDeSLZOBVrE9qGUAsYQkrAGH8.YgfbfArJs58S", "valentin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 496, DateTimeKind.Local).AddTicks(779), new DateTime(2022, 7, 31, 1, 15, 14, 496, DateTimeKind.Local).AddTicks(798), "stefan_roberts@pfannerstill.biz", "Jett", "Maggio", "$2a$11$XPNOezyjnL4i/FyXLNzpL.8/vFqsY0FUd.nYwR8HvRxxGgwUH1QeK", "dejah_thiel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 647, DateTimeKind.Local).AddTicks(3942), new DateTime(2022, 7, 31, 1, 15, 14, 647, DateTimeKind.Local).AddTicks(3960), "joany@parisian.co.uk", "Johan", "Klocko", "$2a$11$eKZIoytVYKa9Tl66q0hdV.CTKN16PXsaV9X6PkxEyEBb5/9CKUc.e", "louisa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 795, DateTimeKind.Local).AddTicks(2161), new DateTime(2022, 7, 31, 1, 15, 14, 795, DateTimeKind.Local).AddTicks(2181), "stanford@vonroob.co.uk", "Aditya", "Connelly", "$2a$11$bJgyZp/Gsvn1KLoyeIyEtea3O.DtDUhCCtfY96lj5urSv7NHh4eg.", "haylee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 14, 943, DateTimeKind.Local).AddTicks(7140), new DateTime(2022, 7, 31, 1, 15, 14, 943, DateTimeKind.Local).AddTicks(7161), "allie.dickens@schustermedhurst.biz", "Lempi", "Hyatt", "$2a$11$3Bu.3C0Zu7guHoCRwcRipuAOlU0Hc4AbYGUlNKW.2WRRKvVu57vqy", "zola.beatty" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 92, DateTimeKind.Local).AddTicks(5292), new DateTime(2022, 7, 31, 1, 15, 15, 92, DateTimeKind.Local).AddTicks(5312), "leanne@connelly.biz", "Cara", "O'Connell", "$2a$11$z3ZvxLLcZOZch7a8BfBd4e5grnARkV5lcht/pBXqJRhOwm6zw4c1a", "gail_halvorson" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(6904), new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(6922), "kayden@grant.co.uk", "Guillermo", "Legros", "$2a$11$tCDtilQV8KoK5nhHX3gopeR9slE4ctkC8Lg8VN4bABDbxzEg8.YqG", "gaylord_kilback" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMetas_Users_UserId",
                table: "UserMetas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
