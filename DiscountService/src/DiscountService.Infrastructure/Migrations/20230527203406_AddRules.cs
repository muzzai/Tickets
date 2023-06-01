using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.AddColumn<Guid>(
                name: "RootRuleGroupId",
                table: "Discounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RuleGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupOperator = table.Column<int>(type: "integer", nullable: false),
                    ParentGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleGroups_RuleGroups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "RuleGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RuleGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Comparand_Address = table.Column<string>(type: "text", nullable: false),
                    Comparand_Type = table.Column<string>(type: "text", nullable: false),
                    Comparer_Address = table.Column<string>(type: "text", nullable: true),
                    Comparer_Type = table.Column<string>(type: "text", nullable: true),
                    IsComparedToValue = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<object>(type: "jsonb", nullable: true),
                    RuleOperator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rule_RuleGroups_RuleGroupId",
                        column: x => x.RuleGroupId,
                        principalTable: "RuleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_RootRuleGroupId",
                table: "Discounts",
                column: "RootRuleGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rule_RuleGroupId",
                table: "Rule",
                column: "RuleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleGroups_ParentGroupId",
                table: "RuleGroups",
                column: "ParentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_RuleGroups_RootRuleGroupId",
                table: "Discounts",
                column: "RootRuleGroupId",
                principalTable: "RuleGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_RuleGroups_RootRuleGroupId",
                table: "Discounts");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "RuleGroups");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_RootRuleGroupId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "RootRuleGroupId",
                table: "Discounts");

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NumberOfFirstCustomers = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_DiscountId",
                table: "Conditions",
                column: "DiscountId");
        }
    }
}
