using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoryModels",
                columns: table => new
                {
                    category_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tittle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    creation_Time = table.Column<DateTime>(nullable: false),
                    lastmodificationTime = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    deletionTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryModels", x => x.category_Id);
                });

            migrationBuilder.CreateTable(
                name: "chapterModels",
                columns: table => new
                {
                    chapter_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tittle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    active = table.Column<bool>(nullable: false),
                    creation_Time = table.Column<DateTime>(nullable: false),
                    lastmodificationTime = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    deletionTime = table.Column<DateTime>(nullable: false),
                    publishedDatetime = table.Column<DateTime>(nullable: false),
                    DepartmentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapterModels", x => x.chapter_Id);
                });

            migrationBuilder.CreateTable(
                name: "mappingModels",
                columns: table => new
                {
                    map_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(nullable: false),
                    chapter_Id = table.Column<int>(nullable: false),
                    creationTime = table.Column<DateTime>(nullable: false),
                    creatorUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mappingModels", x => x.map_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryModels");

            migrationBuilder.DropTable(
                name: "chapterModels");

            migrationBuilder.DropTable(
                name: "mappingModels");
        }
    }
}
