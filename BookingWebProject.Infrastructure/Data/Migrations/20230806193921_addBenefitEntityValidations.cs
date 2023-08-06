using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addBenefitEntityValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Benefits",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassIcon",
                table: "Benefits",
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
                defaultValue: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(5780));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Benefits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ClassIcon",
                table: "Benefits",
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
                defaultValue: new DateTime(2023, 8, 5, 9, 54, 5, 151, DateTimeKind.Local).AddTicks(5780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 6, 22, 39, 20, 861, DateTimeKind.Local).AddTicks(8180));

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
    }
}
