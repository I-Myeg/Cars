using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManafacturerId",
                table: "Cars",
                column: "ManafacturerId");

            migrationBuilder.Sql(@"INSERT INTO public.""Engines""(
	""EngineId"", ""EngineCapacity"", ""Power"", ""EngineConfiguration"", ""Torque"")
	VALUES (300, 22, 131, 'Рядный', 196);");

            migrationBuilder.Sql(@"INSERT INTO public.""Manafacturers""(
	""ManafacturerId"", ""Fabricator"", ""DateOfFoundation"", ""Director"", ""Workers"", ""Branch"", ""ContactInformation"")
	VALUES (200, 'Toyota', 1937, 'Такэси Утиямада', 375235, 'автомобильная промышленность', 'global.toyota');");

            migrationBuilder.Sql(@"UPDATE public.""Cars""
	SET ""EngineId""=300, ""ManafacturerId""=200;");
    
            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "EngineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manafacturers_ManafacturerId",
                table: "Cars",
                column: "ManafacturerId",
                principalTable: "Manafacturers",
                principalColumn: "ManafacturerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manafacturers_ManafacturerId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ManafacturerId",
                table: "Cars");
        }
    }
}
