using MESHWorksAPQP.Repository.Database.StoredProcedures.APQP;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class AddedAlwaysEditable_GetAPQPTemplateDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetAPQPTemplateDetails.Body07062022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetAPQPTemplateDetails.Body30052022);
        }
    }
}
