using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class materialidqueries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e184147e-3743-43da-a5da-f266f5a76d8c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52bbdc78-7055-465b-b2d3-ef81efae4422"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("89e3c98f-9136-47ac-9d94-01bebdc18cff"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 61, 156, 0, 2, 60, 64, 238, 150, 213, 120, 161, 244, 169, 157, 67, 140, 143, 214, 23, 3, 181, 114, 123, 52, 29, 151, 142, 63, 213, 23, 171, 127, 158, 170, 239, 2, 247, 215, 53, 171, 48, 156, 89, 134, 123, 226, 129, 237, 105, 217, 70, 135, 131, 116, 33, 43, 45, 90, 80, 38, 98, 24, 129, 236 }, new byte[] { 247, 227, 214, 87, 215, 187, 195, 232, 6, 213, 254, 155, 117, 153, 188, 173, 42, 213, 34, 9, 49, 52, 224, 181, 194, 236, 30, 45, 67, 17, 176, 148, 29, 254, 212, 99, 236, 198, 76, 87, 205, 201, 166, 190, 142, 234, 186, 243, 176, 192, 197, 209, 190, 225, 14, 175, 179, 212, 253, 54, 5, 39, 107, 246, 106, 166, 164, 49, 242, 241, 68, 245, 8, 18, 14, 44, 247, 106, 214, 8, 193, 179, 82, 223, 51, 135, 37, 239, 42, 183, 66, 100, 144, 90, 246, 104, 183, 188, 196, 244, 110, 156, 23, 14, 201, 20, 164, 67, 157, 57, 159, 129, 179, 36, 28, 190, 184, 137, 15, 111, 83, 37, 243, 166, 60, 12, 233, 174 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("719cc404-7202-4135-ab30-294372f86fc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("89e3c98f-9136-47ac-9d94-01bebdc18cff") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("719cc404-7202-4135-ab30-294372f86fc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("89e3c98f-9136-47ac-9d94-01bebdc18cff"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("52bbdc78-7055-465b-b2d3-ef81efae4422"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 74, 209, 240, 186, 62, 85, 216, 28, 159, 157, 58, 29, 38, 52, 229, 44, 170, 239, 9, 100, 241, 186, 35, 204, 39, 165, 103, 150, 74, 9, 218, 73, 229, 156, 21, 168, 194, 251, 140, 58, 141, 215, 239, 247, 152, 9, 212, 194, 165, 193, 96, 118, 2, 236, 120, 50, 157, 70, 73, 232, 121, 225, 113, 81 }, new byte[] { 38, 127, 187, 238, 36, 81, 126, 214, 151, 5, 211, 189, 120, 26, 27, 206, 30, 116, 205, 47, 100, 67, 113, 162, 237, 167, 206, 220, 110, 14, 224, 208, 228, 168, 46, 197, 175, 74, 178, 145, 72, 120, 150, 136, 45, 130, 157, 204, 61, 74, 83, 135, 56, 10, 41, 251, 68, 122, 172, 193, 188, 18, 3, 163, 104, 204, 166, 175, 240, 74, 177, 36, 124, 42, 63, 21, 94, 134, 96, 201, 18, 66, 157, 195, 230, 9, 67, 81, 169, 196, 151, 176, 3, 36, 114, 33, 89, 119, 107, 93, 180, 66, 83, 214, 80, 210, 218, 95, 184, 132, 175, 184, 255, 123, 63, 197, 198, 221, 141, 250, 139, 174, 9, 114, 141, 91, 184, 132 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e184147e-3743-43da-a5da-f266f5a76d8c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("52bbdc78-7055-465b-b2d3-ef81efae4422") });
        }
    }
}
