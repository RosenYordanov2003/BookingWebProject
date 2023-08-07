using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class changePriceInRoomEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1020));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 19, 1, 1, 425, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeea3b8f-d7b3-4afb-8c7d-b681ee3f3fdf", new DateTime(2023, 8, 7, 17, 42, 22, 32, DateTimeKind.Local).AddTicks(7532), "AQAAAAEAACcQAAAAEJ1E7kT+hBiY2ON9NyH7TPFwd/p6Ro3WKUzsNQVDnbdFFCLHLkAopB3+87hN2u8YUg==", "305cf76d-3cbd-4279-9147-b6cfd83d73ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c9c1ce4-888a-4fc5-9949-67ef1ca856b7", new DateTime(2023, 8, 7, 17, 42, 22, 32, DateTimeKind.Local).AddTicks(7590), "AQAAAAEAACcQAAAAEB2oHeWzhdHj49YFruDPImSf98HzDMo/u3bNX3aWFeB+XTdK9bMxn/d0kRjYCy8r5w==", "934b0470-d996-415a-90da-7e9f76892144" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1249));

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
    }
}
