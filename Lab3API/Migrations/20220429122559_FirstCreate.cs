using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3API.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserInterestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    InterestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.UserInterestID);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Lyssna, spela och sjunga", "Musik" },
                    { 2, "Skapa applikationer, databaser, använda C#", "Programmering" },
                    { 3, "Läsa faktaböcker, sköntlitteratur och självbiografier", "Läsning" },
                    { 4, "Träna kondition, styrka och rörlighet", "Träning" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Blåbärsvägen 11B", "Per", "Andersson", "082767829" },
                    { 2, "Långvägen 5", "Johan", "Karlsson", "0313456789" },
                    { 3, "Fabriksgatan 5", "Johanna", "Nordin", "0903456789" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "UserInterestID", "InterestID", "UserID" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestID",
                table: "UserInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserID",
                table: "UserInterests",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
