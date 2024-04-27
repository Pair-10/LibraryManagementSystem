using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class articlematerialid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 226, 225, 234, 225, 15, 238, 188, 255, 150, 60, 156, 24, 114, 178, 190, 18, 42, 159, 210, 141, 43, 99, 16, 191, 177, 82, 142, 0, 62, 195, 19, 253, 161, 180, 193, 175, 141, 79, 86, 236, 216, 119, 176, 65, 135, 246, 88, 0, 167, 111, 204, 240, 67, 62, 242, 248, 175, 32, 177, 166, 94, 120, 148, 80 }, new byte[] { 141, 56, 252, 104, 94, 222, 203, 251, 170, 27, 143, 206, 47, 77, 17, 132, 1, 185, 98, 247, 227, 54, 3, 59, 246, 202, 86, 159, 236, 57, 15, 164, 113, 48, 57, 64, 234, 192, 108, 248, 81, 100, 28, 64, 38, 148, 180, 121, 66, 39, 0, 119, 69, 50, 79, 220, 83, 236, 217, 12, 169, 196, 134, 22, 113, 184, 96, 125, 146, 119, 154, 230, 195, 213, 194, 225, 197, 121, 206, 253, 254, 72, 158, 151, 219, 64, 129, 47, 237, 127, 145, 106, 106, 61, 168, 145, 113, 88, 65, 189, 248, 208, 35, 217, 8, 7, 50, 21, 182, 19, 142, 12, 1, 129, 236, 134, 30, 31, 92, 253, 189, 171, 6, 125, 99, 4, 195, 104 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("91113a7d-9d84-453a-89d5-89451a9a5c5e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("91113a7d-9d84-453a-89d5-89451a9a5c5e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("89e3c98f-9136-47ac-9d94-01bebdc18cff"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 61, 156, 0, 2, 60, 64, 238, 150, 213, 120, 161, 244, 169, 157, 67, 140, 143, 214, 23, 3, 181, 114, 123, 52, 29, 151, 142, 63, 213, 23, 171, 127, 158, 170, 239, 2, 247, 215, 53, 171, 48, 156, 89, 134, 123, 226, 129, 237, 105, 217, 70, 135, 131, 116, 33, 43, 45, 90, 80, 38, 98, 24, 129, 236 }, new byte[] { 247, 227, 214, 87, 215, 187, 195, 232, 6, 213, 254, 155, 117, 153, 188, 173, 42, 213, 34, 9, 49, 52, 224, 181, 194, 236, 30, 45, 67, 17, 176, 148, 29, 254, 212, 99, 236, 198, 76, 87, 205, 201, 166, 190, 142, 234, 186, 243, 176, 192, 197, 209, 190, 225, 14, 175, 179, 212, 253, 54, 5, 39, 107, 246, 106, 166, 164, 49, 242, 241, 68, 245, 8, 18, 14, 44, 247, 106, 214, 8, 193, 179, 82, 223, 51, 135, 37, 239, 42, 183, 66, 100, 144, 90, 246, 104, 183, 188, 196, 244, 110, 156, 23, 14, 201, 20, 164, 67, 157, 57, 159, 129, 179, 36, 28, 190, 184, 137, 15, 111, 83, 37, 243, 166, 60, 12, 233, 174 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("719cc404-7202-4135-ab30-294372f86fc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("89e3c98f-9136-47ac-9d94-01bebdc18cff") });
        }
    }
}
