using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addIsDeletedProperyInPictureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(3855));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pictures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(3855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 2, 18, 27, 43, 239, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04de2509-64e4-42df-99d3-3052b9d64a0c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEPNj8K87sPdXhhuXRdY2IS9czj0++/Ogec3c4hRV9E05J4jFc+YCqkOJ7u7OIWOJJg==", "81b227ea-a48b-4540-b4a4-2f2b059f3d68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "JoinTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed882457-473a-4116-aa8d-0d13f07c2e1a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEOArApVrY5HexJSCddkKew7oE9W0IdOjncV7D8ChoOL3XhtAAi4chr4/yRQbMFtTjA==", "04792946-c621-41f2-8d9d-4892e8988ca2" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 1, 14, 22, 6, 552, DateTimeKind.Local).AddTicks(4288));
        }
    }
}
