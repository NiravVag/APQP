using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class CustomFieldPropertiesOverride : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMultiSelect",
                schema: "CustomField",
                table: "CustomField",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaxDate",
                schema: "CustomField",
                table: "CustomField",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                schema: "CustomField",
                table: "CustomField",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxValue",
                schema: "CustomField",
                table: "CustomField",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MinDate",
                schema: "CustomField",
                table: "CustomField",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinLength",
                schema: "CustomField",
                table: "CustomField",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinValue",
                schema: "CustomField",
                table: "CustomField",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomFieldPropertiesOverride",
                schema: "CustomField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    APQPTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tooltip = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    ValidationRegex = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ValidationMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentFeildId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsVisibleOnSelection = table.Column<bool>(type: "bit", nullable: false),
                    MinValue = table.Column<int>(type: "int", nullable: true),
                    MaxValue = table.Column<int>(type: "int", nullable: true),
                    MinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MinLength = table.Column<int>(type: "int", nullable: true),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    IsMultiSelect = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldPropertiesOverride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldPropertiesOverride_APQPTemplate_APQPTemplateId",
                        column: x => x.APQPTemplateId,
                        principalSchema: "APQP",
                        principalTable: "APQPTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldPropertiesOverride_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalSchema: "CustomField",
                        principalTable: "CustomField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldPropertiesOverride_APQPTemplateId",
                schema: "CustomField",
                table: "CustomFieldPropertiesOverride",
                column: "APQPTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldPropertiesOverride_CustomFieldId",
                schema: "CustomField",
                table: "CustomFieldPropertiesOverride",
                column: "CustomFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFieldPropertiesOverride",
                schema: "CustomField");

            migrationBuilder.DropColumn(
                name: "IsMultiSelect",
                schema: "CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "MaxDate",
                schema: "CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                schema: "CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "MaxValue",
                schema: "CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "MinDate",
                schema: "CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "MinLength",
                schema: "CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "MinValue",
                schema: "CustomField",
                table: "CustomField");
        }
    }
}
