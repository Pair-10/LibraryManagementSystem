using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ddc09d45-90d6-4aed-bd02-09217b9bfb4d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b821153d-3462-4e10-ac54-cc9c1f09dd13"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("7bb2c912-8bea-4ba7-aa7d-12e1e7da66bb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 39, 92, 186, 210, 32, 224, 99, 138, 21, 66, 20, 5, 87, 98, 39, 183, 22, 219, 18, 103, 26, 147, 207, 89, 39, 99, 211, 11, 1, 119, 231, 246, 204, 189, 167, 81, 142, 79, 177, 22, 89, 35, 28, 74, 136, 197, 195, 75, 133, 176, 100, 191, 7, 117, 69, 81, 168, 130, 146, 157, 191, 117, 192, 208 }, new byte[] { 211, 208, 61, 185, 133, 194, 129, 38, 21, 73, 122, 54, 197, 175, 208, 195, 232, 132, 141, 96, 1, 202, 131, 215, 47, 223, 239, 191, 73, 107, 227, 80, 48, 37, 125, 80, 238, 102, 207, 78, 152, 183, 233, 92, 196, 117, 243, 141, 9, 122, 45, 239, 220, 185, 186, 133, 208, 148, 248, 128, 17, 114, 111, 133, 216, 161, 147, 109, 12, 77, 68, 104, 155, 72, 101, 51, 86, 95, 192, 26, 242, 241, 187, 38, 20, 231, 210, 88, 138, 175, 89, 88, 79, 53, 19, 157, 1, 46, 189, 200, 84, 37, 184, 252, 252, 52, 66, 131, 228, 94, 196, 133, 125, 160, 162, 12, 14, 234, 198, 57, 96, 123, 71, 159, 252, 181, 124, 253 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("64ab915f-9840-4491-846f-892513c07dc4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7bb2c912-8bea-4ba7-aa7d-12e1e7da66bb") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("64ab915f-9840-4491-846f-892513c07dc4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7bb2c912-8bea-4ba7-aa7d-12e1e7da66bb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("b821153d-3462-4e10-ac54-cc9c1f09dd13"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 108, 42, 105, 37, 234, 141, 186, 16, 240, 189, 250, 142, 170, 76, 119, 134, 77, 56, 117, 197, 32, 242, 133, 213, 175, 209, 47, 30, 103, 37, 122, 51, 163, 27, 24, 24, 140, 98, 240, 166, 112, 155, 192, 91, 210, 197, 61, 246, 118, 219, 120, 226, 99, 154, 229, 48, 230, 85, 240, 252, 24, 203, 17, 80 }, new byte[] { 9, 24, 137, 72, 235, 83, 29, 116, 99, 114, 15, 47, 20, 50, 105, 35, 164, 198, 140, 94, 192, 108, 31, 20, 213, 188, 106, 146, 25, 158, 242, 19, 171, 246, 161, 36, 94, 242, 150, 158, 226, 116, 12, 239, 9, 40, 53, 162, 110, 246, 58, 153, 53, 79, 131, 42, 186, 226, 242, 253, 168, 60, 191, 15, 13, 149, 46, 158, 94, 239, 10, 112, 90, 63, 125, 137, 128, 198, 74, 14, 39, 176, 35, 169, 72, 7, 169, 233, 118, 181, 177, 205, 40, 1, 156, 146, 33, 79, 231, 200, 93, 99, 158, 190, 202, 55, 255, 176, 224, 220, 205, 232, 195, 132, 13, 139, 197, 41, 59, 115, 27, 84, 115, 159, 107, 29, 188, 235 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ddc09d45-90d6-4aed-bd02-09217b9bfb4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b821153d-3462-4e10-ac54-cc9c1f09dd13") });
        }
    }
}
