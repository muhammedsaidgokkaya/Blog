using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace blog.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMesajs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(type: "text", nullable: true),
                    Konu = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMesajs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ResimYol = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Eposta = table.Column<string>(type: "text", nullable: true),
                    Saatler = table.Column<string>(type: "text", nullable: true),
                    Facebook = table.Column<string>(type: "text", nullable: true),
                    Twitter = table.Column<string>(type: "text", nullable: true),
                    Instagram = table.Column<string>(type: "text", nullable: true),
                    LinkedIn = table.Column<string>(type: "text", nullable: true),
                    Youtube = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMesajs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(type: "text", nullable: true),
                    Konu = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMesajs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(type: "text", nullable: true),
                    Konu = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Tarih = table.Column<string>(type: "text", nullable: true),
                    Popular = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Trend = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ResimYol = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryBaslik = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMesajs");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Iletisims");

            migrationBuilder.DropTable(
                name: "UserMesajs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
