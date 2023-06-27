using MESHWorksAPQP.Repository.Database.StoredProcedures.APQP;
using MESHWorksAPQP.Repository.Database.StoredProcedures.APQPTemplate;
using MESHWorksAPQP.Repository.Database.StoredProcedures.CustomField;
using MESHWorksAPQP.Repository.Database.StoredProcedures.Gate;
using MESHWorksAPQP.Repository.Database.StoredProcedures.Part;
using MESHWorksAPQP.Repository.Database.StoredProcedures.Role;
using MESHWorksAPQP.Repository.Database.StoredProcedures.UserManagement;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class Create_StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(CloneAPQPTemplate.Body);
            migrationBuilder.Sql(GetAPQPData.Body);
            migrationBuilder.Sql(GetAPQPDiscussions.Body);
            migrationBuilder.Sql(GetAPQPTemplateDetails.Body17052022);
            migrationBuilder.Sql(GetAPQPTemplateGates.Body);
            migrationBuilder.Sql(GetAPQPTemplates.Body);
            migrationBuilder.Sql(GetPartDetails.Body);
            migrationBuilder.Sql(GetPartRelations.Body);
            migrationBuilder.Sql(SaveGateFieldsData.Body13032022);

            migrationBuilder.Sql(GetActiveCustomFields.Body);
            migrationBuilder.Sql(GetCustomFields.Body);

            migrationBuilder.Sql(GetRolePermissions.Body);
            migrationBuilder.Sql(GetUserMenu.Body);
            migrationBuilder.Sql(GetUserPermissionByCode.Body);
            migrationBuilder.Sql(GetUserPermissions.Body);
            migrationBuilder.Sql(SaveRolePermissions.Body);

            migrationBuilder.Sql(GetAllUserManagement.Body);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[CloneAPQPTemplate]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetAPQPData]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetAPQPDiscussions]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetAPQPTemplateDetails]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetAPQPTemplateGates]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetAPQPTemplates]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetPartDetails]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetPartRelations]");
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[SaveGateFieldsData]");

            migrationBuilder.Sql("DROP PROCEDURE [CustomField].[GetActiveCustomFields]");
            migrationBuilder.Sql("DROP PROCEDURE [CustomField].[GetCustomFields]");

            migrationBuilder.Sql("DROP PROCEDURE [Role].[GetRolePermissions]");
            migrationBuilder.Sql("DROP PROCEDURE [Role].[GetUserMenu]");
            migrationBuilder.Sql("DROP PROCEDURE [Role].[GetUserPermissionByCode]");
            migrationBuilder.Sql("DROP PROCEDURE [Role].[GetUserPermissions]");
            migrationBuilder.Sql("DROP PROCEDURE [Role].[SaveRolePermissions]");

            migrationBuilder.Sql("DROP PROCEDURE [Setup].[GetAllUserManagement]");
        }
    }
}
