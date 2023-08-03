using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addIsDeletedPropertyToHotelBenefits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HotelBenefits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d96946a8-0b99-48f4-8b34-b2970e6c4542", new DateTime(2023, 8, 3, 10, 3, 9, 658, DateTimeKind.Local).AddTicks(8862), "AQAAAAEAACcQAAAAENSQm6aShXjc0bW6Ey3qhDULUwgoiecvv14vBVTkqIKJ/ufOZunK7Dq1/kfzBOXGFA==", "728b5bc2-1aa8-4d44-83ea-d3f4de81c1d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eeb11e78-9a07-4f5e-b88e-fb0956fdf50b", new DateTime(2023, 8, 3, 10, 3, 9, 658, DateTimeKind.Local).AddTicks(8912), "AQAAAAEAACcQAAAAEOHQKzvc4XBlghPU24kwtUO6EcVCTNwqE8iiiPjIualZaQTJ0KiHxWyE7uGR73ZaNQ==", "04ca68fe-58f5-4511-a299-cdc6d5107683" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1855));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HotelBenefits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d23e13-1ce6-4789-97f4-35145b65c26e", new DateTime(2023, 8, 2, 18, 27, 43, 236, DateTimeKind.Local).AddTicks(6610), "AQAAAAEAACcQAAAAEDdWY14Wt1nVXw1AOKTOundRWklVhcl7L23WK6NiEfnVfKorAol6NuyE4c0ECOW/cA==", "37f65821-1cfe-488f-991c-9774bba5a830" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a0b1f6a-b2c8-44ee-b6a7-a5191aa33025", new DateTime(2023, 8, 2, 18, 27, 43, 236, DateTimeKind.Local).AddTicks(6661), "AQAAAAEAACcQAAAAEBJ4a2o5ou0P8ujQOi7XE3GcvgLEDFBqKhV2wW3IsZUTMLzd99bit9Krd8tz0Q3P+w==", "d5dc7d1d-d937-4988-8c1d-686dd4fef5bd" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(864));
        }
    }
}
