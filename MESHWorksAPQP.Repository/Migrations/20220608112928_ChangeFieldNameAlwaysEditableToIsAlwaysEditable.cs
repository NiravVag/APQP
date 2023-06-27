using MESHWorksAPQP.Repository.Database.StoredProcedures.APQP;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MESHWorksAPQP.Repository.Migrations
{
    public partial class ChangeFieldNameAlwaysEditableToIsAlwaysEditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                schema: "APQP",
                table: "APQP");

            migrationBuilder.RenameColumn(
                name: "AlwaysEditable",
                schema: "APQP",
                table: "Gate",
                newName: "IsAlwaysEditable");

            migrationBuilder.Sql(GetAPQPTemplateDetails.Body08062022);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAlwaysEditable",
                schema: "APQP",
                table: "Gate",
                newName: "AlwaysEditable");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                schema: "APQP",
                table: "APQP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(GetAPQPTemplateDetails.Body07062022);
        }
    }
}
