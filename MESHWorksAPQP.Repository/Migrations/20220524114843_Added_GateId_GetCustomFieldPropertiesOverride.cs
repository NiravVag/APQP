using MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class Added_GateId_GetCustomFieldPropertiesOverride : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetCustomFieldPropertiesOverride.Body24052022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [CustomField].[GetCustomFieldPropertiesOverride]");
        }
    }
}
