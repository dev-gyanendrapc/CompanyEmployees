using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployees.Migrations
{
    public partial class AddedRolesToDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a616ee0-aee3-49b9-a4c4-39ede22dd019");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8decdedf-656f-4376-8065-c3067c6bdddd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "898de464-9d21-486a-8c4a-a28be3083c00", "7aa7c5d4-7f97-4f1c-99b0-a1dfdc95b2e0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8608af6-5130-4a76-a8f2-6f0bf4dc2650", "6835a14d-ffba-4cd5-b3d1-40c25b1d2280", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "898de464-9d21-486a-8c4a-a28be3083c00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8608af6-5130-4a76-a8f2-6f0bf4dc2650");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a616ee0-aee3-49b9-a4c4-39ede22dd019", "7a563728-8768-4123-bb69-d00ce6488725", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8decdedf-656f-4376-8065-c3067c6bdddd", "002324c4-a452-465d-b0b0-1722bdb8f673", "Manager", "MANAGER" });
        }
    }
}
