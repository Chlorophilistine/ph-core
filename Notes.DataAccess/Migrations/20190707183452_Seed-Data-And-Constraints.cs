using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.DataAccess.Migrations
{
    public partial class SeedDataAndConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Company", "Created", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { 1, "1 High Street, Edinburgh", "Amalgamated Holdings", new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "joe@bloggs.com", "Joe", "Bloggs", 0 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Company", "Created", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { 2, "456 High Street, Edinburgh", "SoleTrader LLP", new DateTime(2010, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "a@smith.com", "Andrea", "Smith", 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Company", "Created", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { 3, "29 Acacia Road, Edinburgh", "Twist Incorporated", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "z@twist.com", "Zachry", "Twist", 2 });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CustomerId" },
                values: new object[,]
                {
                    { 1, "My first note", 1 },
                    { 2, "Prospective customer, follow up on lead", 1 },
                    { 3, "Current customer, due quarterly sales review", 2 },
                    { 4, "For review", 2 },
                    { 5, "Sales order follow up", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
