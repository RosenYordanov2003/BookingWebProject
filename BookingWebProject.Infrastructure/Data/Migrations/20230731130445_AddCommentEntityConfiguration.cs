using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class AddCommentEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Hotels_HotelId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4727cf5b-d8bc-447d-8841-0030566da367", "AQAAAAEAACcQAAAAENPzWKlK6m7gExVd75V4nKvk3dHUqrs6p9BwCT8UAVuKWbtm4jAym9g9RcnPKDJK0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "2ee0f98c-ccac-4639-875c-10bd9cf1483c", "ADMIN123@GMAIL.COM", "AQAAAAEAACcQAAAAEOW9pIPaqmzH6NeEpLICYtj3id20KxKU4mKA02zqqBGbtnVFtTR1SYEqnQUr1Bq/xg==" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "Description", "HotelId", "IsDeleted", "UserId", "UserName" },
                values: new object[,]
                {
                    { 13, new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2381), "Test Comment", 1, false, new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), "Test User" },
                    { 14, new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2417), "Test Comment", 2, false, new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), "Test User" },
                    { 15, new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2419), "Test Comment", 3, false, new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), "Test User" },
                    { 16, new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2421), "Test Comment", 4, false, new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), "Test User" },
                    { 17, new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2423), "Test Comment", 5, false, new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), "Test User" },
                    { 18, new DateTime(2023, 7, 31, 16, 4, 44, 399, DateTimeKind.Local).AddTicks(2455), "Test Comment", 6, false, new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), "Test User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Hotels_HotelId",
                table: "Comments",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Hotels_HotelId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab7addb5-9ded-4e53-bbc0-b4e92c970878", "AQAAAAEAACcQAAAAELhfVzCbAkm/YFnQlCL8iZqq56XVtdgHHWzrxCKazXUSYhQcKwxUW3DouIugab8Jag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "a1c025a8-5c13-4a57-b298-17fff616bab4", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENUwd4VONpKCg6QvKuiYfwiLDvUYzY0avsGgDKlVlRKnrYXeHbny15WHp914rsF7RA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Hotels_HotelId",
                table: "Comments",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
