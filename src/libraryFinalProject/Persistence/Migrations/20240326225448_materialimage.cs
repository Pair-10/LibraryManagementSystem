using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class materialimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1b123c94-e2e3-4762-954e-9546d26beb15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7bfd0f62-f601-456d-afe7-a91974f35d20"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "MaterialImage",
                table: "Materials",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("1d5dd65b-5a40-4d43-86af-e0ffe5c9e58e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 42, 223, 197, 13, 171, 206, 93, 75, 46, 181, 234, 214, 204, 240, 47, 70, 153, 178, 72, 124, 11, 23, 241, 112, 143, 169, 108, 160, 189, 223, 7, 226, 175, 126, 45, 183, 218, 123, 193, 100, 219, 253, 224, 221, 162, 196, 247, 24, 54, 128, 51, 141, 136, 130, 131, 174, 153, 254, 136, 100, 211, 116, 250, 39 }, new byte[] { 128, 163, 250, 182, 104, 55, 179, 187, 32, 149, 229, 207, 162, 61, 232, 156, 186, 226, 236, 180, 164, 249, 143, 254, 70, 78, 99, 105, 181, 67, 255, 95, 42, 157, 63, 207, 43, 9, 98, 195, 32, 8, 86, 234, 232, 128, 73, 235, 153, 191, 62, 159, 44, 236, 41, 30, 208, 144, 116, 158, 55, 81, 230, 172, 185, 68, 232, 96, 253, 244, 190, 36, 71, 209, 51, 161, 99, 197, 244, 196, 139, 14, 150, 100, 10, 168, 90, 169, 195, 62, 183, 180, 252, 193, 214, 128, 45, 125, 178, 162, 4, 23, 9, 189, 243, 186, 103, 240, 125, 174, 127, 62, 185, 91, 134, 177, 68, 35, 12, 243, 243, 56, 153, 222, 55, 218, 126, 81 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a8e3a377-218d-47be-992c-5c3af4dd797d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1d5dd65b-5a40-4d43-86af-e0ffe5c9e58e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a8e3a377-218d-47be-992c-5c3af4dd797d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d5dd65b-5a40-4d43-86af-e0ffe5c9e58e"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "MaterialImage",
                table: "Materials",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("7bfd0f62-f601-456d-afe7-a91974f35d20"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 33, 41, 166, 77, 247, 192, 164, 165, 55, 212, 44, 27, 52, 143, 196, 59, 122, 21, 142, 116, 180, 17, 42, 214, 209, 132, 42, 90, 255, 168, 28, 10, 245, 55, 62, 21, 236, 113, 208, 249, 2, 141, 198, 127, 107, 229, 223, 243, 21, 62, 38, 50, 29, 155, 181, 248, 98, 97, 38, 34, 98, 68, 195, 104 }, new byte[] { 45, 8, 21, 76, 156, 239, 248, 120, 32, 200, 52, 195, 202, 104, 50, 119, 96, 243, 33, 167, 203, 8, 245, 73, 220, 235, 165, 235, 192, 28, 195, 137, 10, 137, 150, 89, 55, 55, 47, 13, 44, 8, 182, 28, 5, 241, 169, 173, 31, 206, 114, 140, 253, 94, 255, 125, 124, 26, 88, 192, 30, 199, 186, 207, 17, 49, 49, 54, 41, 176, 38, 189, 174, 107, 75, 54, 103, 111, 1, 117, 155, 24, 165, 27, 115, 253, 55, 91, 207, 158, 109, 21, 184, 157, 150, 132, 4, 193, 220, 136, 125, 28, 176, 103, 129, 108, 75, 82, 145, 253, 18, 22, 148, 163, 54, 255, 52, 67, 216, 30, 158, 78, 227, 19, 127, 249, 73, 246 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1b123c94-e2e3-4762-954e-9546d26beb15"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7bfd0f62-f601-456d-afe7-a91974f35d20") });
        }
    }
}
