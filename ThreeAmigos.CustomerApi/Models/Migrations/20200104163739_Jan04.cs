using Microsoft.EntityFrameworkCore.Migrations;

namespace ThreeAmigos.CustomerApi.Models.Migrations
{
    public partial class Jan04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "BrandName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "StockLevel",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<bool>(
                name: "RequestedDelete",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDelete",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Products",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Products",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "StockLevel",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
