using MESHWorksAPQP.Repository.Database.StoredProcedures.Part;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class Added_IsDeleted_Flag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetPartRelations.Body06062022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetPartRelations.Body19052022);
        }
    }
}