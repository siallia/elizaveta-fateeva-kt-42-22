using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace elizaveta_fateeva_kt_42_22.Migrations
{
    /// <inheritdoc />
    public partial class uppBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "department_id",
                table: "cd_teacher",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "head_of_department_id",
                table: "cd_department",
                type: "integer",
                nullable: true,
                comment: "Идентификатор заведующего кафедрой",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Идентификатор заведующего кафедрой");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "department_id",
                table: "cd_teacher",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "head_of_department_id",
                table: "cd_department",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Идентификатор заведующего кафедрой",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "Идентификатор заведующего кафедрой");
        }
    }
}
