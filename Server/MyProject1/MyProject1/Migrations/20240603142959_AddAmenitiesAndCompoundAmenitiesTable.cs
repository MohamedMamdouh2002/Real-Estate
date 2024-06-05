using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject1.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenitiesAndCompoundAmenitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompoundId",
                table: "RealEStates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompoundAmenities",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompoundAmenities", x => new { x.AmenitiesId, x.CompoundId });
                    table.ForeignKey(
                        name: "FK_CompoundAmenities_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompoundAmenities_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_Name",
                table: "Amenities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompoundAmenities_CompoundId",
                table: "CompoundAmenities",
                column: "CompoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEStates_Compounds_CompoundId",
                table: "RealEStates",
                column: "CompoundId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEStates_Compounds_CompoundId",
                table: "RealEStates");

            migrationBuilder.DropTable(
                name: "CompoundAmenities");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropIndex(
                name: "IX_RealEStates_CompoundId",
                table: "RealEStates");

            migrationBuilder.DropColumn(
                name: "CompoundId",
                table: "RealEStates");
        }
    }
}
