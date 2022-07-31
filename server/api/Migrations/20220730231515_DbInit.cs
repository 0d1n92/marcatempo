using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Giustifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giustifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Entry = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Exit = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPresent = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    GiustificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Giustifications_GiustificationId",
                        column: x => x.GiustificationId,
                        principalTable: "Giustifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Actions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QRcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    token = table.Column<string>(type: "varchar(40)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRcodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRcodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserMetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    metaLabel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMetas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "All Permission", "Administrator" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Only marking and show", "Operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "ModifyDate", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 31, 1, 15, 13, 902, DateTimeKind.Local).AddTicks(8235), new DateTime(2022, 7, 31, 1, 15, 13, 902, DateTimeKind.Local).AddTicks(8280), "admin@mail.com", "admin", "admin", null, "$2a$11$T37BPZdYjcRe2QyRXM27h.F.3JXTNUV43vcrvBUBuR2oKBzGefzY2", 1, "Administrator" },
                    { 2, new DateTime(2022, 7, 31, 1, 15, 14, 50, DateTimeKind.Local).AddTicks(9688), new DateTime(2022, 7, 31, 1, 15, 14, 50, DateTimeKind.Local).AddTicks(9761), "operator@mail.com", "operator", "operator", null, "$2a$11$j00A22I1jZGgSnHer.k.BOMPzGUsByj35cDX7v7HsGjWLssJPXnwi", 2, "Operator" },
                    { 3, new DateTime(2022, 7, 31, 1, 15, 14, 199, DateTimeKind.Local).AddTicks(6678), new DateTime(2022, 7, 31, 1, 15, 14, 199, DateTimeKind.Local).AddTicks(6770), "pippo@mail.com", "Jonh", "Doe", null, "$2a$11$avPxGVtMx66uU8siqLHrK.08BfzaMsUvP1.sa4wmpF8PAZsafEXlm", 2, "Pippo" },
                    { 4, new DateTime(2022, 7, 31, 1, 15, 14, 347, DateTimeKind.Local).AddTicks(9860), new DateTime(2022, 7, 31, 1, 15, 14, 347, DateTimeKind.Local).AddTicks(9879), "destinee_rowe@morarkeeling.uk", "Maia", "Hermiston", null, "$2a$11$8prUH2./1w5osWcfDeSLZOBVrE9qGUAsYQkrAGH8.YgfbfArJs58S", 2, "valentin" },
                    { 5, new DateTime(2022, 7, 31, 1, 15, 14, 496, DateTimeKind.Local).AddTicks(779), new DateTime(2022, 7, 31, 1, 15, 14, 496, DateTimeKind.Local).AddTicks(798), "stefan_roberts@pfannerstill.biz", "Jett", "Maggio", null, "$2a$11$XPNOezyjnL4i/FyXLNzpL.8/vFqsY0FUd.nYwR8HvRxxGgwUH1QeK", 2, "dejah_thiel" },
                    { 6, new DateTime(2022, 7, 31, 1, 15, 14, 647, DateTimeKind.Local).AddTicks(3942), new DateTime(2022, 7, 31, 1, 15, 14, 647, DateTimeKind.Local).AddTicks(3960), "joany@parisian.co.uk", "Johan", "Klocko", null, "$2a$11$eKZIoytVYKa9Tl66q0hdV.CTKN16PXsaV9X6PkxEyEBb5/9CKUc.e", 2, "louisa" },
                    { 7, new DateTime(2022, 7, 31, 1, 15, 14, 795, DateTimeKind.Local).AddTicks(2161), new DateTime(2022, 7, 31, 1, 15, 14, 795, DateTimeKind.Local).AddTicks(2181), "stanford@vonroob.co.uk", "Aditya", "Connelly", null, "$2a$11$bJgyZp/Gsvn1KLoyeIyEtea3O.DtDUhCCtfY96lj5urSv7NHh4eg.", 2, "haylee" },
                    { 8, new DateTime(2022, 7, 31, 1, 15, 14, 943, DateTimeKind.Local).AddTicks(7140), new DateTime(2022, 7, 31, 1, 15, 14, 943, DateTimeKind.Local).AddTicks(7161), "allie.dickens@schustermedhurst.biz", "Lempi", "Hyatt", null, "$2a$11$3Bu.3C0Zu7guHoCRwcRipuAOlU0Hc4AbYGUlNKW.2WRRKvVu57vqy", 2, "zola.beatty" },
                    { 9, new DateTime(2022, 7, 31, 1, 15, 15, 92, DateTimeKind.Local).AddTicks(5292), new DateTime(2022, 7, 31, 1, 15, 15, 92, DateTimeKind.Local).AddTicks(5312), "leanne@connelly.biz", "Cara", "O'Connell", null, "$2a$11$z3ZvxLLcZOZch7a8BfBd4e5grnARkV5lcht/pBXqJRhOwm6zw4c1a", 2, "gail_halvorson" },
                    { 10, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(6904), new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(6922), "kayden@grant.co.uk", "Guillermo", "Legros", null, "$2a$11$tCDtilQV8KoK5nhHX3gopeR9slE4ctkC8Lg8VN4bABDbxzEg8.YqG", 2, "gaylord_kilback" }
                });

            migrationBuilder.InsertData(
                table: "QRcodes",
                columns: new[] { "Id", "CreationDate", "UpdateDate", "UserId", "token" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7422), null, 2, "81a130d2-502f-4cf1-a376-63edeb000e9f" },
                    { 2, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7427), null, 3, "67c5064b-7160-4d05-a62e-1799f0d13270" },
                    { 3, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7451), null, 4, "860b05e5-a462-4660-a438-18ab536c2bee" },
                    { 4, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7453), null, 5, "15794b8a-be18-4c51-8c6a-4eb2d066da01" },
                    { 5, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7455), null, 6, "11e2ba74-2038-4044-b121-63248df0d048" },
                    { 6, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7457), null, 7, "f04e7c53-d221-4523-be89-8da0efd774c3" },
                    { 7, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7459), null, 8, "d8fcec27-a178-4164-bbc5-398232b207c1" },
                    { 8, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7460), null, 9, "3c790b7c-e480-4150-b9ac-7968b1f9dc88" },
                    { 9, new DateTime(2022, 7, 31, 1, 15, 15, 240, DateTimeKind.Local).AddTicks(7467), null, 10, "a18f0984-1cde-4ba5-9366-3aa14c8ed3ca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_GiustificationId",
                table: "Actions",
                column: "GiustificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_UserId",
                table: "Actions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QRcodes_token",
                table: "QRcodes",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRcodes_UserId",
                table: "QRcodes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMetas_UserId",
                table: "UserMetas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "QRcodes");

            migrationBuilder.DropTable(
                name: "UserMetas");

            migrationBuilder.DropTable(
                name: "Giustifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
