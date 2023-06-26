using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTrackerProject.Migrations
{
    /// <inheritdoc />
    public partial class IdUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
        name: "NewIdColumn",
        table: "AspNetUsers",
        type: "uniqueidentifier",
        nullable: false,
        defaultValueSql: "NEWID()");

            migrationBuilder.Sql("UPDATE dbo.AspNetUsers SET NewIdColumn = CAST(Id AS uniqueidentifier)");
            migrationBuilder.DropColumn(
        name: "Id",
        table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "NewIdColumn",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
