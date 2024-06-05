using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject1.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentPlanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentPlansForCompound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlansForCompound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPlansForCompound_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPlansForRealEState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Persenter = table.Column<int>(type: "int", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: false),
                    RestPrice = table.Column<int>(type: "int", nullable: false),
                    Installment = table.Column<int>(type: "int", nullable: false),
                    RealEStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlansForRealEState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPlansForRealEState_RealEStates_RealEStateId",
                        column: x => x.RealEStateId,
                        principalTable: "RealEStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlansForCompound_CompoundId",
                table: "PaymentPlansForCompound",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlansForRealEState_RealEStateId",
                table: "PaymentPlansForRealEState",
                column: "RealEStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentPlansForCompound");

            migrationBuilder.DropTable(
                name: "PaymentPlansForRealEState");
        }
    }
}
