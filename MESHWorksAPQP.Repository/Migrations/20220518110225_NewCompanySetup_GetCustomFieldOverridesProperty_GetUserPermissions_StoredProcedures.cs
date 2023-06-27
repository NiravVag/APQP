using MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField;
using MESHWorksAPQP.Repository.Database.StoredProcedures.Role;
using MESHWorksAPQP.Repository.Database.StoredProcedures.Setup;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class NewCompanySetup_GetCustomFieldOverridesProperty_GetUserPermissions_StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetUserPermissions.Body);
            migrationBuilder.Sql(NewCompanySetup.Body18052022);
            migrationBuilder.Sql(GetCustomFieldPropertiesOverride.Body18052022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [Role].[GetUserPermissions]");
            migrationBuilder.Sql("DROP PROCEDURE [Setup].[NewCompanySetup]");
            migrationBuilder.Sql("DROP PROCEDURE [CustomField].[GetCustomFieldPropertiesOverride]");
        }
    }
}
