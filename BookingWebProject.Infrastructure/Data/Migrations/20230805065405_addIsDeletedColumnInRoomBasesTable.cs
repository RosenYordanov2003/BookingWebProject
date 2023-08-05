using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addIsDeletedColumnInRoomBasesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RoomsBases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(5780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78e3f61c-b85c-4c99-ba1e-07690630cd71", new DateTime(2023, 8, 5, 9, 54, 5, 149, DateTimeKind.Local).AddTicks(2098), "AQAAAAEAACcQAAAAEMKhw4ZOBQARie2FAk88x9bGNJTjPhOwvuoawFvTkp/jgZz5nGMcXghMcmaomo/sew==", "d4cd8381-01a4-44c0-be27-b1fbc60c1c8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f14c793-f2da-4b15-921e-6935912348f1", new DateTime(2023, 8, 5, 9, 54, 5, 149, DateTimeKind.Local).AddTicks(2152), "AQAAAAEAACcQAAAAEEdolOer3hHvMbRrIC8NbpdG7L5aQLfNNgRiTnqAyFjdVHaYURl0ISUhizRWDNC1Dg==", "cdb1e73c-6f71-45a6-8922-7c9a597198f9" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(6065));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RoomsBases");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f0ec5c-0f0d-45ab-8f3c-344fd4bff515", new DateTime(2023, 8, 4, 17, 3, 15, 129, DateTimeKind.Local).AddTicks(6967), "AQAAAAEAACcQAAAAEAwMAI3vc0QzuRUJ+bVJlE0YY3BZmAuLRQspQ3ukE9C8yKwS5xdEPnb1aKhpmQn35A==", "7fe97b1c-4b23-42c5-994a-1fd9c355703b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c1738c5-70da-4384-9a81-5328a7e1b7dd", new DateTime(2023, 8, 4, 17, 3, 15, 129, DateTimeKind.Local).AddTicks(7023), "AQAAAAEAACcQAAAAEBDLkef4JEeDKc3xZtvQdRVT3xNYNGUui3tNEhElu5rwpeUkGGmsruRatCiP/Vh7Jw==", "5bed8b58-e39f-45ea-9d82-057c11d9a8ec" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9858));
        }
    }
}
