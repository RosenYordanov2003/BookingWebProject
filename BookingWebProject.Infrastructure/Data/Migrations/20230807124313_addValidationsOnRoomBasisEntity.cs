using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addValidationsOnRoomBasisEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomBasis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassIcon",
                table: "RoomBasis",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8180));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomBasis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ClassIcon",
                table: "RoomBasis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 15, 43, 13, 161, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af43270a-2d81-4145-bb20-ec2679062cd6", new DateTime(2023, 8, 6, 22, 39, 20, 859, DateTimeKind.Local).AddTicks(3293), "AQAAAAEAACcQAAAAELaDPRYZZRIZfy7xR12pCvrfl3tx0+mpRA2NA4eZjbss9F02wCP6qv2XmYWlY/0MxA==", "b101b7f5-f842-440f-a94b-6d43718c1d71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f69a9c1d-35c8-431b-8bba-ea1192af042c", new DateTime(2023, 8, 6, 22, 39, 20, 859, DateTimeKind.Local).AddTicks(3352), "AQAAAAEAACcQAAAAEFNWL5CUmMnAWrsxtSCsszOpWIqKTr8eFaDDlcQx7o1GKvaNu6l8fWbBE6W6aNP95g==", "98c72d9e-b14d-448c-be72-7bc6435a35d1" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8634));
        }
    }
}
