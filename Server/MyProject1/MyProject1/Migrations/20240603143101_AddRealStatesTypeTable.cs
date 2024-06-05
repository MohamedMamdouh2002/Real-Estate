using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject1.Migrations
{
    /// <inheritdoc />
    public partial class AddRealStatesTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealStatesTypeId",
                table: "RealEStates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RealEStateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEStateTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEStates_RealStatesTypeId",
                table: "RealEStates",
                column: "RealStatesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEStates_RealEStateTypes_RealStatesTypeId",
                table: "RealEStates",
                column: "RealStatesTypeId",
                principalTable: "RealEStateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEStates_RealEStateTypes_RealStatesTypeId",
                table: "RealEStates");

            migrationBuilder.DropTable(
                name: "RealEStateTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealEStates_RealStatesTypeId",
                table: "RealEStates");

            migrationBuilder.DropColumn(
                name: "RealStatesTypeId",
                table: "RealEStates");
        }
    }
}
