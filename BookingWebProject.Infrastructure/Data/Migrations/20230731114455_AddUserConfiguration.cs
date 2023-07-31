using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class AddUserConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicturePath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), 0, "6e41c6ba-e501-485a-80ec-1b4d204b13ab", "testuser123@gmail.com", false, null, null, false, null, "TESTUSER123@GMAIL.COM", "TEST USER", "AQAAAAEAACcQAAAAEK9lnoCiwCC7BNA/isLw3I+EfeAm9dNfF2JdPVqgqY2IA5Jz/biO7YeLtKY0KgBHaQ==", null, false, null, null, false, "Test User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicturePath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"), 0, "69252b5a-6226-4908-b66a-fd91d782d032", "admin123@gmail.com", false, null, null, false, null, "ADMIN@GMAIL.COM", "Admin", null, null, false, null, null, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"));
        }
    }
}
