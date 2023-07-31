using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class AddSecurityStampToSeededUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4727cf5b-d8bc-447d-8841-0030566da367", "AQAAAAEAACcQAAAAENPzWKlK6m7gExVd75V4nKvk3dHUqrs6p9BwCT8UAVuKWbtm4jAym9g9RcnPKDJK0g==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ee0f98c-ccac-4639-875c-10bd9cf1483c", "AQAAAAEAACcQAAAAEOW9pIPaqmzH6NeEpLICYtj3id20KxKU4mKA02zqqBGbtnVFtTR1SYEqnQUr1Bq/xg==", null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2455));
        }
    }
}
