using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cars.Migrations
{
    /// <inheritdoc />
    public partial class AddColorAndCountryHandbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountyUnit",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ColorUnit",
                table: "Colors");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ColorCode",
                table: "Colors",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Colors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Colors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Colors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Colors",
                newName: "ColorCode");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "CountyUnit",
                table: "Countries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Colors",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ColorUnit",
                table: "Colors",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "ColorId");
        }
    }
}
