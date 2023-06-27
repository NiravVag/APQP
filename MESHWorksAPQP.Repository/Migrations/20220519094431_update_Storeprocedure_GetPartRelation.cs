using MESHWorksAPQP.Repository.Database.StoredProcedures.Part;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class update_Storeprocedure_GetPartRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetPartRelations.Body19052022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(GetPartRelations.Body);
        }
    }
}
