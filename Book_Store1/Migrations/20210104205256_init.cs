using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    My_ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookDbSet_AuthorDbSet_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookDbSet_AuthorId",
                table: "BookDbSet",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookDbSet");

            migrationBuilder.DropTable(
                name: "AuthorDbSet");
        }
    }
}
