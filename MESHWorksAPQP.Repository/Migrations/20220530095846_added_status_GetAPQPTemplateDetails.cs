using MESHWorksAPQP.Repository.Database.StoredProcedures.APQP;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class added_status_GetAPQPTemplateDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetAPQPTemplateDetails.Body30052022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetAPQPTemplateDetails.Body28032022);
        }
    }
}
