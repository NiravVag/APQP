using MESHWorksAPQP.Repository.Database.StoredProcedures.APQPTemplate;
using MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField;
using MESHWorksAPQP.Repository.Database.StoredProcedures.Role;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class GetRolePermissons_GetActiveCustomFields_CloneAPQPTemplate_StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(CloneAPQPTemplate.Body18052022);
            migrationBuilder.Sql(GetActiveCustomFields.Body18052022);
            migrationBuilder.Sql(GetRolePermissions.Body19052022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[CloneAPQPTemplate]");
            migrationBuilder.Sql("DROP PROCEDURE [CustomField].[GetActiveCustomFields]");
            migrationBuilder.Sql("DROP PROCEDURE [Role].[GetRolePermissions]");
        }
    }
}
