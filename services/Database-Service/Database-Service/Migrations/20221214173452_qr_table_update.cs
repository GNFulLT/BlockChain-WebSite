using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseService.Migrations
{
    /// <inheritdoc />
    public partial class qrtableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_qr_table_user_table_UserId",
                table: "qr_table");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "qr_table",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "qr_table",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "QrImagePath",
                table: "qr_table",
                newName: "qr_image_path");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "qr_table",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_qr_table_UserId",
                table: "qr_table",
                newName: "IX_qr_table_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_qr_table_user_table_user_id",
                table: "qr_table",
                column: "user_id",
                principalTable: "user_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_qr_table_user_table_user_id",
                table: "qr_table");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "qr_table",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "qr_table",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "qr_image_path",
                table: "qr_table",
                newName: "QrImagePath");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "qr_table",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_qr_table_user_id",
                table: "qr_table",
                newName: "IX_qr_table_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_qr_table_user_table_UserId",
                table: "qr_table",
                column: "UserId",
                principalTable: "user_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
