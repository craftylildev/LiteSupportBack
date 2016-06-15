using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiteSupport.Migrations
{
    public partial class EditCustEmplPropNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "EmailE",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstNameE",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastNameE",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneE",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailC",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstNameC",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastNameC",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneC",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailE",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FirstNameE",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastNameE",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PhoneE",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmailC",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstNameC",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastNameC",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneC",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customer",
                nullable: true);
        }
    }
}
