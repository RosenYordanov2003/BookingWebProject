using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class addAdminPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f63c615c-1a61-44c6-9878-bccc48267daf", "AQAAAAEAACcQAAAAEAbnH5xNKWBb48i7PzIlUHPhnrQgDZsXK4iS/c+HEzKfpTPZqUx+R+IPrsHapJ79AA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "724ac4ab-7df5-4fd3-9622-96da9c027f75", "AQAAAAEAACcQAAAAEK0fnKG80in0pPmDSt26iJtXM4kGHkoNaA3K5mvF9tpe6eA4WWg5FUtheie0ol8asA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e41c6ba-e501-485a-80ec-1b4d204b13ab", "AQAAAAEAACcQAAAAEK9lnoCiwCC7BNA/isLw3I+EfeAm9dNfF2JdPVqgqY2IA5Jz/biO7YeLtKY0KgBHaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed842fdc-c71b-4fbc-8df5-6f97cb73d622"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69252b5a-6226-4908-b66a-fd91d782d032", null });
        }
    }
}
