using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addIsDeletedColumnInRoomTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RoomTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9052));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RoomTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 17, 42, 22, 35, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e22dbb5-e71e-429f-acf3-03ffe9ef7c3e", new DateTime(2023, 8, 7, 15, 43, 13, 159, DateTimeKind.Local).AddTicks(5297), "AQAAAAEAACcQAAAAEMvpvfWR+5s9Z3C6dtsZke1htP5r7C175LLymfsqK3LDAzbYxrqY0eIvqY2+aw5U8A==", "fbd4d818-c956-46ce-8f5e-93399b638802" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68598811-e054-4e07-a59b-766b4db25d53", new DateTime(2023, 8, 7, 15, 43, 13, 159, DateTimeKind.Local).AddTicks(5352), "AQAAAAEAACcQAAAAEIbqCkAAJiVIRmDVyEP58Wxv75JkKS5cg0xjFEfLC4lmPHNICfG9zrNmMT6FJ1KefA==", "c8d60bb0-d4f6-4d5b-be82-8a403ee2759e" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9279));
        }
    }
}
