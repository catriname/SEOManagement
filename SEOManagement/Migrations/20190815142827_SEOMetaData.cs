using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEOManagement.Migrations
{
    public partial class SEOMetaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SEOMetaData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    H1 = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEOMetaData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SEOMetaData",
                columns: new[] { "Id", "Description", "H1", "Path", "Title" },
                values: new object[,]
                {
                    { 1, "Default Description", "Default H1", ".", "Default Title" },
                    { 2, "Home Description", "Home H1", "/", "Home Title" },
                    { 3, "About Us Description", "About Us H1", "/Home/About", "About Us Title" },
                    { 4, "SamplePage1 Description", "SamplePage1 H1", "/Home/SamplePage1", "SamplePage1 Title" },
                    { 5, "SamplePage2 Description", "SamplePage2 H1", "/Home/SamplePage2", "SamplePage2 Title" },
                    { 6, "Privacy Description", "Privacy H1", "/Home/Privacy", "Privacy Title" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SEOMetaData");
        }
    }
}
