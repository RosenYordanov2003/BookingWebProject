using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class AddNewPropertyToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04de2509-64e4-42df-99d3-3052b9d64a0c", "AQAAAAEAACcQAAAAEPNj8K87sPdXhhuXRdY2IS9czj0++/Ogec3c4hRV9E05J4jFc+YCqkOJ7u7OIWOJJg==", "81b227ea-a48b-4540-b4a4-2f2b059f3d68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed882457-473a-4116-aa8d-0d13f07c2e1a", "AQAAAAEAACcQAAAAEOArApVrY5HexJSCddkKew7oE9W0IdOjncV7D8ChoOL3XhtAAi4chr4/yRQbMFtTjA==", "04792946-c621-41f2-8d9d-4892e8988ca2" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4288));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1819a12d-9182-42d0-8921-654358e4369b", "AQAAAAEAACcQAAAAEIZOnyierVMSL+B7cbdct3TZIK/ztk1l4RyhE9EY09royUje8OTrsL1u/YkNwkYX0A==", "c9606066-6bf2-42a5-be5e-6185b08d4ff2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "819be88b-fd7b-49eb-96a2-3421b4582804", "AQAAAAEAACcQAAAAEHsAsBZYW4REk4lg/CnOymL87MTsA5rbh2oWqCx6fhFLzMvj06J2VSFRw2nA3CGcNw==", "a84173d2-515b-499d-9078-bc22cd4542bd" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 23, 6, 353, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 23, 6, 353, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 23, 6, 353, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 23, 6, 353, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 23, 6, 353, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 23, 6, 353, DateTimeKind.Local).AddTicks(1064));
        }
    }
}
