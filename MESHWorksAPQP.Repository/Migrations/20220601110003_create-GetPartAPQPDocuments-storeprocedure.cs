using MESHWorksAPQP.Repository.Database.StoredProcedures.APQP;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class CreateGetPartAPQPDocumentsstoreprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetPartAPQPDocuments.Body);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [APQP].[GetPartAPQPDocuments]");
        }
    }
}
