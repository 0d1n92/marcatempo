using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Dbinit : Migration
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
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    Username = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                columns: new[] { "Id", "CreationDate", "DateOfBirth", "Email", "FirstName", "LastName", "ModifyDate", "Password", "RoleId", "Token", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 20, 23, 3, 53, 117, DateTimeKind.Local).AddTicks(1687), new DateTime(2022, 7, 20, 23, 3, 53, 117, DateTimeKind.Local).AddTicks(1751), null, "admin", "admin", null, "$2a$11$Vq5U9P2BVI24IyGfdLpbWeULwZ/t2RejCPuMEvJYc5PINZ25THZF.", 1, null, "Administrator" },
                    { 2, new DateTime(2022, 7, 20, 23, 3, 53, 265, DateTimeKind.Local).AddTicks(7100), new DateTime(2022, 7, 20, 23, 3, 53, 265, DateTimeKind.Local).AddTicks(7132), null, "operator", "operator", null, "$2a$11$S5/s/4kigUp7hmnf6fLlTuAhoV0aj9ZK3Au6avjEt/F4px0ac0WCm", 2, null, "Operator" },
                    { 3, new DateTime(2022, 7, 20, 23, 3, 53, 416, DateTimeKind.Local).AddTicks(9927), new DateTime(2022, 7, 20, 23, 3, 53, 417, DateTimeKind.Local).AddTicks(2), null, "Jonh", "Doe", null, "$2a$11$KWAX85M0NVuntHi/N/2rfe6rW6JoAY/aZgXVV6/Z06JfF7EWrccju", 2, null, "Pippo" },
                    { 4, new DateTime(2022, 7, 20, 23, 3, 53, 565, DateTimeKind.Local).AddTicks(5460), new DateTime(2022, 7, 20, 23, 3, 53, 565, DateTimeKind.Local).AddTicks(5491), null, "Hunter", "Schmidt", null, "$2a$11$0L/dgczJvXEQroRYYNrGIO8EYXLYDfuoLL2Irm4YKkSe9Bcq9eIty", 2, null, "arielle" },
                    { 5, new DateTime(2022, 7, 20, 23, 3, 53, 717, DateTimeKind.Local).AddTicks(8320), new DateTime(2022, 7, 20, 23, 3, 53, 717, DateTimeKind.Local).AddTicks(8352), null, "Helene", "Hills", null, "$2a$11$RQmX726DCCUVPUTkmCJ1GuFaASBY5ICV2agbyn761teY6geQQaX5O", 2, null, "ruben" },
                    { 6, new DateTime(2022, 7, 20, 23, 3, 53, 866, DateTimeKind.Local).AddTicks(4601), new DateTime(2022, 7, 20, 23, 3, 53, 866, DateTimeKind.Local).AddTicks(4629), null, "Unique", "Oberbrunner", null, "$2a$11$GuE7N9mrLYoTRRvj47Yoiexg3.Y9iJQEvpMchFvpZq5sxTC3HlZNG", 2, null, "audrey.konopelski" },
                    { 7, new DateTime(2022, 7, 20, 23, 3, 54, 15, DateTimeKind.Local).AddTicks(9638), new DateTime(2022, 7, 20, 23, 3, 54, 15, DateTimeKind.Local).AddTicks(9666), null, "Wiley", "Roob", null, "$2a$11$jKCS0CShf5QpjISrZ0QS9.ifnlGqG63a86XuhFvRY6Vc4B6JdnyCy", 2, null, "elta" },
                    { 8, new DateTime(2022, 7, 20, 23, 3, 54, 164, DateTimeKind.Local).AddTicks(5676), new DateTime(2022, 7, 20, 23, 3, 54, 164, DateTimeKind.Local).AddTicks(5704), null, "Elisha", "Stokes", null, "$2a$11$4MPrETWyC09jy8DlmTkseuIuaR1wIqPjxUVB.2FVjb18qomA9vg.e", 2, null, "deborah" },
                    { 9, new DateTime(2022, 7, 20, 23, 3, 54, 313, DateTimeKind.Local).AddTicks(2339), new DateTime(2022, 7, 20, 23, 3, 54, 313, DateTimeKind.Local).AddTicks(2368), null, "Jamel", "Ziemann", null, "$2a$11$IMeg3lyORLRggsdR6xrTEuvhbzLsSRcghnGLGq.08buyS08SFZuh.", 2, null, "wava_reinger" },
                    { 10, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(5577), new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(5605), null, "Naomi", "Welch", null, "$2a$11$M.vwVLKPQI0wc3itBBq9luiQkEq3YT7JW4lnjpDyLznrcLOZar24u", 2, null, "charlotte_stiedemann" }
                });

            migrationBuilder.InsertData(
                table: "QRcodes",
                columns: new[] { "Id", "CreationDate", "UpdateDate", "UserId", "token" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6151), null, 2, "81a130d2-502f-4cf1-a376-63edeb000e9f" },
                    { 2, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6155), null, 3, "67c5064b-7160-4d05-a62e-1799f0d13270" },
                    { 3, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6187), null, 4, "7775286b-4123-4e89-ba8e-f59dec0deb2a" },
                    { 4, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6199), null, 5, "dde23727-5cae-4cf0-8adf-3ee8238d33b1" },
                    { 5, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6201), null, 6, "426b8696-84d2-45d2-91b7-eb4eccece2fc" },
                    { 6, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6203), null, 7, "02dc24d8-5f53-4e4a-b1c7-5636b864e6c2" },
                    { 7, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6205), null, 8, "0c49a450-b2ba-4024-ac97-3482de9618b8" },
                    { 8, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6207), null, 9, "63b0a13c-6366-45ec-8586-119a384de033" },
                    { 9, new DateTime(2022, 7, 20, 23, 3, 54, 465, DateTimeKind.Local).AddTicks(6208), null, 10, "961c4a82-9a03-4211-8b9a-60d986f66398" }
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
