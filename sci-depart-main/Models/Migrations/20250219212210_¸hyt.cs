using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class hyt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c1e7563-6bc8-417a-bfda-d5289e32fb02", "AQAAAAIAAYagAAAAEJSkesbHcZTGVE2s58TszqWJgw8hWn8Li/0StyHl305kOXaMn/tJdvjLW/UW0PgLDg==", "3c6cebe7-eb52-46c0-b7b4-cc9a6497f3ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc1cb24c-7154-48c2-b429-ed48815fbaea", "3df341e6-543f-424e-8ba4-275f3fe04e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ebded9f3-8628-4803-9add-3d6d52a38732", "6677b349-4e36-4837-b946-32fd25b5cce6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d90be2a7-51fd-4e65-8e26-eba9d4815bfe", "AQAAAAIAAYagAAAAEOVt1wVeB7LKm2y7AutHUTb7LvFqr10MRIGo9cluyCD3uQtM5QiycbQ8yIICKgMnpA==", "ed48b30d-9f6c-400b-9808-bed8f85e34dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "835f1a01-cb33-43d7-a535-743ddb4220cc", "a0475058-1db0-4880-98fd-513dc1c31e5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa766780-b0f2-4ec2-b55f-200e8d1a955b", "837611a7-e5f4-4523-b138-db6150f7f6f5" });
        }
    }
}
