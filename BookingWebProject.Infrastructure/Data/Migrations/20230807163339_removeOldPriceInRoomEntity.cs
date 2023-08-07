using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class removeOldPriceInRoomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3437),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62e380aa-51f0-4487-8192-91f4157f1039", new DateTime(2023, 8, 7, 19, 33, 38, 623, DateTimeKind.Local).AddTicks(382), "AQAAAAEAACcQAAAAEPA/MYfZJYfcKIi/ZTdfHQx6QNWQ5AZ/WBHFhPZ4VHmcefSHj8sdc1zm95a8midb7Q==", "c63caba7-5191-4b4d-879e-33ac69aea6b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb5caaff-246e-4b24-a4a4-2a7319395ba8", new DateTime(2023, 8, 7, 19, 33, 38, 623, DateTimeKind.Local).AddTicks(440), "AQAAAAEAACcQAAAAEJ9/6C6Tzpx1mvHQsd6xcpXEEyFNxKD8Lso8oWkMscrwZsUsuRuT1DQRiu5IuWqzAg==", "0edb6a62-47d8-455d-99c3-c837b2ca171d" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerNight",
                value: 190m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerNight",
                value: 190m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "PricePerNight",
                value: 220m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "PricePerNight",
                value: 200m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "PricePerNight",
                value: 200m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "PricePerNight",
                value: 180m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "PricePerNight",
                value: 180m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "PricePerNight",
                value: 190m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "PricePerNight",
                value: 190m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "PricePerNight",
                value: 280m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "PricePerNight",
                value: 280m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "PricePerNight",
                value: 280m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                column: "PricePerNight",
                value: 290m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "PricePerNight",
                value: 290m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 19, 33, 38, 625, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ccfcb4e-390f-49d4-b46a-3e99d249c0da", new DateTime(2023, 8, 7, 19, 16, 14, 121, DateTimeKind.Local).AddTicks(9761), "AQAAAAEAACcQAAAAEGHtgK3RcJgT2+ElnuwUqg5I3897qA3mS5e2P9tyejv8zyfgifBta0ee3hHfh8mI8A==", "a370a39a-f4b8-463d-8df4-c4b439ac5ab0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd58aa39-d611-4d0d-918f-00fb5fb04b94", new DateTime(2023, 8, 7, 19, 16, 14, 121, DateTimeKind.Local).AddTicks(9814), "AQAAAAEAACcQAAAAEF45j8NrkAQVVFELC76NuUDQbSzfan+YWHz9x+AR2TlVRChi84fddxvI8iQLaGRJiQ==", "3d08be6f-16f4-47a7-8e30-5e011a9c1ffd" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerNight",
                value: 247m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerNight",
                value: 266m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "PricePerNight",
                value: 286m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "PricePerNight",
                value: 280m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "PricePerNight",
                value: 290m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "PricePerNight",
                value: 243m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "PricePerNight",
                value: 252m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "PricePerNight",
                value: 247m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "PricePerNight",
                value: 266m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "PricePerNight",
                value: 364m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "PricePerNight",
                value: 378m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "PricePerNight",
                value: 392m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                column: "PricePerNight",
                value: 406m);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "PricePerNight",
                value: 377m);
        }
    }
}
