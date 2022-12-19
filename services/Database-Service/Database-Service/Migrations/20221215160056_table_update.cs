using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseService.Migrations
{
    /// <inheritdoc />
    public partial class tableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_product_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_user_table_user_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_user_table_user_id",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "wallet_table");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "transaction_table");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product_table");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_user_id",
                table: "wallet_table",
                newName: "IX_wallet_table_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_user_id",
                table: "transaction_table",
                newName: "IX_transaction_table_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_product_id",
                table: "transaction_table",
                newName: "IX_transaction_table_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wallet_table",
                table: "wallet_table",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction_table",
                table: "transaction_table",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_table",
                table: "product_table",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_table_product_table_product_id",
                table: "transaction_table",
                column: "product_id",
                principalTable: "product_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_table_user_table_user_id",
                table: "transaction_table",
                column: "user_id",
                principalTable: "user_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_table_user_table_user_id",
                table: "wallet_table",
                column: "user_id",
                principalTable: "user_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_table_product_table_product_id",
                table: "transaction_table");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_table_user_table_user_id",
                table: "transaction_table");

            migrationBuilder.DropForeignKey(
                name: "FK_wallet_table_user_table_user_id",
                table: "wallet_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wallet_table",
                table: "wallet_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction_table",
                table: "transaction_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_table",
                table: "product_table");

            migrationBuilder.RenameTable(
                name: "wallet_table",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "transaction_table",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "product_table",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_wallet_table_user_id",
                table: "Wallets",
                newName: "IX_Wallets_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_table_user_id",
                table: "Transactions",
                newName: "IX_Transactions_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_table_product_id",
                table: "Transactions",
                newName: "IX_Transactions_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_product_id",
                table: "Transactions",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_user_table_user_id",
                table: "Transactions",
                column: "user_id",
                principalTable: "user_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_user_table_user_id",
                table: "Wallets",
                column: "user_id",
                principalTable: "user_table",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
