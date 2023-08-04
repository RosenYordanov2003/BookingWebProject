using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class chaneRoomEntityValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "RentCars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d8ec6ad-1075-4da5-8376-4988b212f9a1", new DateTime(2023, 8, 4, 15, 3, 0, 576, DateTimeKind.Local).AddTicks(7111), "AQAAAAEAACcQAAAAED2LFzlK5evjicXtRGZ9hzUhs0X20TIuC/eQTrmsGt72j9UYJagT48HdX1cnTxj5kw==", "00026858-4b81-4b42-92f7-47add2d84086" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95859d44-c8e5-4423-89cb-f66eca47973c", new DateTime(2023, 8, 4, 15, 3, 0, 576, DateTimeKind.Local).AddTicks(7167), "AQAAAAEAACcQAAAAEBhV105jnk3QjGVzwLwIfvM+L7ccwk8VvBbtWwarhOJD+JzJ2v4awtJQzqy4IH6EvA==", "8567461c-d2ae-47fd-96b0-e11c8337d122" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PricePerNight", "RoomTypeId" },
                values: new object[] { 325m, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "RentCars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 10, 3, 9, 661, DateTimeKind.Local).AddTicks(1566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9712));

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

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PricePerNight", "RoomTypeId" },
                values: new object[] { 351m, 3 });
        }
    }
}
