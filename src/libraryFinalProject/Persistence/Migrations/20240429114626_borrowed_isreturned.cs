using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class borrowed_isreturned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("91113a7d-9d84-453a-89d5-89451a9a5c5e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "BorrowedMaterials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("e2a56d07-02d1-4ddd-8598-45953ae0906a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 22, 35, 94, 41, 61, 130, 241, 163, 108, 217, 80, 194, 28, 244, 237, 96, 152, 158, 248, 84, 197, 2, 216, 65, 63, 164, 99, 143, 101, 177, 129, 171, 172, 244, 150, 230, 134, 129, 36, 36, 58, 109, 217, 207, 186, 15, 0, 131, 223, 71, 74, 32, 63, 31, 171, 85, 229, 63, 194, 51, 245, 232, 229, 27 }, new byte[] { 187, 219, 49, 67, 108, 197, 163, 62, 241, 52, 146, 204, 87, 38, 152, 24, 175, 249, 86, 190, 161, 154, 241, 240, 244, 215, 137, 147, 32, 54, 46, 47, 191, 200, 192, 117, 51, 173, 50, 51, 11, 130, 192, 80, 172, 92, 90, 154, 156, 29, 72, 133, 127, 149, 22, 8, 15, 221, 36, 204, 238, 71, 249, 203, 229, 194, 54, 178, 246, 54, 54, 244, 54, 15, 112, 31, 82, 59, 253, 215, 187, 234, 99, 9, 46, 233, 230, 87, 219, 137, 35, 92, 156, 190, 139, 251, 40, 165, 133, 82, 175, 33, 118, 199, 61, 58, 12, 114, 136, 192, 221, 123, 8, 194, 142, 69, 5, 58, 28, 41, 197, 178, 64, 10, 119, 84, 125, 217 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3f24371f-6e9b-4418-9448-7d89baf639e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e2a56d07-02d1-4ddd-8598-45953ae0906a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3f24371f-6e9b-4418-9448-7d89baf639e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2a56d07-02d1-4ddd-8598-45953ae0906a"));

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "BorrowedMaterials");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 226, 225, 234, 225, 15, 238, 188, 255, 150, 60, 156, 24, 114, 178, 190, 18, 42, 159, 210, 141, 43, 99, 16, 191, 177, 82, 142, 0, 62, 195, 19, 253, 161, 180, 193, 175, 141, 79, 86, 236, 216, 119, 176, 65, 135, 246, 88, 0, 167, 111, 204, 240, 67, 62, 242, 248, 175, 32, 177, 166, 94, 120, 148, 80 }, new byte[] { 141, 56, 252, 104, 94, 222, 203, 251, 170, 27, 143, 206, 47, 77, 17, 132, 1, 185, 98, 247, 227, 54, 3, 59, 246, 202, 86, 159, 236, 57, 15, 164, 113, 48, 57, 64, 234, 192, 108, 248, 81, 100, 28, 64, 38, 148, 180, 121, 66, 39, 0, 119, 69, 50, 79, 220, 83, 236, 217, 12, 169, 196, 134, 22, 113, 184, 96, 125, 146, 119, 154, 230, 195, 213, 194, 225, 197, 121, 206, 253, 254, 72, 158, 151, 219, 64, 129, 47, 237, 127, 145, 106, 106, 61, 168, 145, 113, 88, 65, 189, 248, 208, 35, 217, 8, 7, 50, 21, 182, 19, 142, 12, 1, 129, 236, 134, 30, 31, 92, 253, 189, 171, 6, 125, 99, 4, 195, 104 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("91113a7d-9d84-453a-89d5-89451a9a5c5e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b") });
        }
    }
}
