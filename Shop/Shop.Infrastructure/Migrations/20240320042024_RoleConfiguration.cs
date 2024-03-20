using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Roles_RoleId",
                table: "RolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission");

            migrationBuilder.EnsureSchema(
                name: "role");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "role");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "Permissions",
                newSchema: "role");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_RoleId",
                schema: "role",
                table: "Permissions",
                newName: "IX_Permissions_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "role",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "role",
                table: "Permissions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Title",
                schema: "role",
                table: "Roles",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "role",
                table: "Permissions",
                column: "RoleId",
                principalSchema: "role",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Title",
                schema: "role",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "role",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "role",
                newName: "RolePermission");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_RoleId",
                table: "RolePermission",
                newName: "IX_RolePermission_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Roles_RoleId",
                table: "RolePermission",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
