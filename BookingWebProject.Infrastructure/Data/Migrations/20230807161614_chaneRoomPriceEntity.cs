using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class chaneRoomPriceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7394));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 19, 16, 14, 124, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f78a454d-98c6-46de-96a4-108bfded74ef", new DateTime(2023, 8, 7, 19, 1, 1, 423, DateTimeKind.Local).AddTicks(4447), "AQAAAAEAACcQAAAAEJ9PiZz1w99aM2taBOlm4uFmV/eJGoudlLrct4JIrZ52cKEBnuZHDKJzTbHtH++JcQ==", "ad22a615-1b0a-4fbf-b071-2ff371c408c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80d7f27f-b951-4dd8-9378-ed4a8c44199c", new DateTime(2023, 8, 7, 19, 1, 1, 423, DateTimeKind.Local).AddTicks(4518), "AQAAAAEAACcQAAAAEIzgQHGYHJXfvjPDAY9XCtnhT247Z9VHRNMIe5Szx+2znPZ5pyAsXEtHPXnK44OWUQ==", "cbfd4974-b1af-44ff-bf52-9f4abd7626fe" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7689));

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
    }
}
