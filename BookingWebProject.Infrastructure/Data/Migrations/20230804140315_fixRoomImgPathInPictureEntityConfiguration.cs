using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class fixRoomImgPathInPictureEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9712));

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

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "Path",
                value: "/img/Rooms/Spa Hotel Dvoretsa SingleRoom2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 4, 15, 3, 0, 578, DateTimeKind.Local).AddTicks(9712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 4, 17, 3, 15, 131, DateTimeKind.Local).AddTicks(9632));

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
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "Path",
                value: "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvorestsa SingleRoom2.jpg");
        }
    }
}
