using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.EF.Migrations
{
    public partial class createtestaggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                "PK_Customer",
                "Customer");

            migrationBuilder.RenameTable(
                "Customer",
                newName: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                "DeletedAt",
                "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                "PK_Customers",
                "Customers",
                "Id");

            migrationBuilder.CreateTable(
                "Aggregates",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TestName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Aggregates", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Aggregates");

            migrationBuilder.DropPrimaryKey(
                "PK_Customers",
                "Customers");

            migrationBuilder.DropColumn(
                "DeletedAt",
                "Customers");

            migrationBuilder.RenameTable(
                "Customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                "PK_Customer",
                "Customer",
                "Id");
        }
    }
}