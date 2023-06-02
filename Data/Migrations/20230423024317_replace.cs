    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class replace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ee643d14-9107-441a-a26c-cc0015faee23");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "416cbf32-7e4f-415e-9818-423c31f5a96a", "AQAAAAEAACcQAAAAEFpNxgu/u/XGyYGsbwKwcuxCbIAA5DAqD9QmQIqLpVZPe4ZQs4NV3vNxo4+OWpa/vA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 23, 9, 43, 16, 802, DateTimeKind.Local).AddTicks(7405));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a130599d-d6d7-4719-8711-7fbb8d59771a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0323dccc-0e28-4a4a-8677-3e33cf86e9fa", "AQAAAAEAACcQAAAAEHlY6k7jCEuebMMdXJ5Ppa1i6EjBNZ0i7I8cIsKFOZ9pAjZqjrz57QID5lImghgrXQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 3, 22, 44, 41, 782, DateTimeKind.Local).AddTicks(3782));
        }
    }
}
