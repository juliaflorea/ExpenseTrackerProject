using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTrackerProject.Migrations
{
    /// <inheritdoc />
    public partial class luck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
    name: "Id",
    table: "AspNetUsers",
    type: "uniqueidentifier",
    nullable: false,
    oldClrType: typeof(int));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
    name: "Id",
    table: "AspNetUsers",
    type: "int",
    nullable: false,
    oldClrType: typeof(Guid));

        }
    }
}
