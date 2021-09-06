using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeDisney.PreAcel.Migrations
{
    public partial class removeMovieOrseriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovieOrSeries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterMovieOrSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    MovieOrSerieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovieOrSeries", x => x.Id);
                });
        }
    }
}
