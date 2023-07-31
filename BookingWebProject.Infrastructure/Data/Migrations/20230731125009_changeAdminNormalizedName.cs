using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingWebProject.Infrastructure.Migrations
{
    public partial class changeAdminNormalizedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "a1c025a8-5c13-4a57-b298-17fff616bab4", "АDMIN", "AQAAAAEAACcQAAAAENUwd4VONpKCg6QvKuiYfwiLDvUYzY0avsGgDKlVlRKnrYXeHbny15WHp914rsF7RA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "724ac4ab-7df5-4fd3-9622-96da9c027f75", "Admin", "AQAAAAEAACcQAAAAEK0fnKG80in0pPmDSt26iJtXM4kGHkoNaA3K5mvF9tpe6eA4WWg5FUtheie0ol8asA==" });
        }
    }
}
