using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_RuleGroups_RootRuleGroupId",
                table: "Discounts");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_RootRuleGroupId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "RootRuleGroupId",
                table: "Discounts");

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "RuleGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RuleGroups_DiscountId",
                table: "RuleGroups",
                column: "DiscountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleGroups_Discounts_DiscountId",
                table: "RuleGroups",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleGroups_Discounts_DiscountId",
                table: "RuleGroups");

            migrationBuilder.DropIndex(
                name: "IX_RuleGroups_DiscountId",
                table: "RuleGroups");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "RuleGroups");

            migrationBuilder.AddColumn<Guid>(
                name: "RootRuleGroupId",
                table: "Discounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContributorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_RootRuleGroupId",
                table: "Discounts",
                column: "RootRuleGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ProjectId",
                table: "ToDoItems",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_RuleGroups_RootRuleGroupId",
                table: "Discounts",
                column: "RootRuleGroupId",
                principalTable: "RuleGroups",
                principalColumn: "Id");
        }
    }
}
