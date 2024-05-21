using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("05860de2-c04e-4de4-919f-1462c92fbf6a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ecebdc81-b04e-4fda-acfd-15248cf3e325"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("b821153d-3462-4e10-ac54-cc9c1f09dd13"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 108, 42, 105, 37, 234, 141, 186, 16, 240, 189, 250, 142, 170, 76, 119, 134, 77, 56, 117, 197, 32, 242, 133, 213, 175, 209, 47, 30, 103, 37, 122, 51, 163, 27, 24, 24, 140, 98, 240, 166, 112, 155, 192, 91, 210, 197, 61, 246, 118, 219, 120, 226, 99, 154, 229, 48, 230, 85, 240, 252, 24, 203, 17, 80 }, new byte[] { 9, 24, 137, 72, 235, 83, 29, 116, 99, 114, 15, 47, 20, 50, 105, 35, 164, 198, 140, 94, 192, 108, 31, 20, 213, 188, 106, 146, 25, 158, 242, 19, 171, 246, 161, 36, 94, 242, 150, 158, 226, 116, 12, 239, 9, 40, 53, 162, 110, 246, 58, 153, 53, 79, 131, 42, 186, 226, 242, 253, 168, 60, 191, 15, 13, 149, 46, 158, 94, 239, 10, 112, 90, 63, 125, 137, 128, 198, 74, 14, 39, 176, 35, 169, 72, 7, 169, 233, 118, 181, 177, 205, 40, 1, 156, 146, 33, 79, 231, 200, 93, 99, 158, 190, 202, 55, 255, 176, 224, 220, 205, 232, 195, 132, 13, 139, 197, 41, 59, 115, 27, 84, 115, 159, 107, 29, 188, 235 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ddc09d45-90d6-4aed-bd02-09217b9bfb4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b821153d-3462-4e10-ac54-cc9c1f09dd13") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("ecebdc81-b04e-4fda-acfd-15248cf3e325"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 32, 119, 231, 128, 48, 47, 162, 96, 16, 81, 20, 226, 48, 249, 234, 233, 236, 71, 251, 50, 104, 46, 73, 178, 119, 121, 128, 6, 62, 148, 181, 246, 60, 1, 215, 63, 101, 241, 78, 44, 79, 42, 144, 62, 66, 5, 115, 156, 208, 119, 73, 184, 236, 72, 32, 203, 173, 190, 118, 36, 170, 177, 213, 148 }, new byte[] { 89, 254, 177, 119, 105, 202, 117, 211, 249, 95, 9, 70, 162, 33, 4, 253, 169, 247, 178, 4, 102, 186, 163, 0, 25, 169, 26, 98, 168, 103, 165, 175, 9, 30, 113, 247, 217, 85, 31, 100, 169, 134, 255, 234, 13, 206, 3, 90, 248, 16, 201, 183, 62, 35, 5, 134, 225, 43, 103, 91, 20, 44, 168, 170, 102, 29, 53, 169, 196, 127, 8, 45, 224, 227, 183, 238, 146, 187, 117, 35, 122, 32, 167, 128, 63, 68, 132, 16, 40, 226, 233, 252, 95, 73, 117, 194, 222, 114, 45, 5, 1, 146, 242, 125, 202, 174, 120, 4, 206, 235, 233, 212, 162, 33, 146, 193, 72, 224, 238, 73, 253, 179, 74, 87, 78, 4, 57, 176 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("05860de2-c04e-4de4-919f-1462c92fbf6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ecebdc81-b04e-4fda-acfd-15248cf3e325") });
        }
    }
}
