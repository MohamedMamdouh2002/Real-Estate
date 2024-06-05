using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject1.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_RealEStates_RealEStateId",
                        column: x => x.RealEStateId,
                        principalTable: "RealEStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RealEStateId",
                table: "Photos",
                column: "RealEStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
