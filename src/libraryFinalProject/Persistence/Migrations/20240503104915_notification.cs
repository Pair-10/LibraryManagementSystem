using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "NotificationDate",
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("ecebdc81-b04e-4fda-acfd-15248cf3e325"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 32, 119, 231, 128, 48, 47, 162, 96, 16, 81, 20, 226, 48, 249, 234, 233, 236, 71, 251, 50, 104, 46, 73, 178, 119, 121, 128, 6, 62, 148, 181, 246, 60, 1, 215, 63, 101, 241, 78, 44, 79, 42, 144, 62, 66, 5, 115, 156, 208, 119, 73, 184, 236, 72, 32, 203, 173, 190, 118, 36, 170, 177, 213, 148 }, new byte[] { 89, 254, 177, 119, 105, 202, 117, 211, 249, 95, 9, 70, 162, 33, 4, 253, 169, 247, 178, 4, 102, 186, 163, 0, 25, 169, 26, 98, 168, 103, 165, 175, 9, 30, 113, 247, 217, 85, 31, 100, 169, 134, 255, 234, 13, 206, 3, 90, 248, 16, 201, 183, 62, 35, 5, 134, 225, 43, 103, 91, 20, 44, 168, 170, 102, 29, 53, 169, 196, 127, 8, 45, 224, 227, 183, 238, 146, 187, 117, 35, 122, 32, 167, 128, 63, 68, 132, 16, 40, 226, 233, 252, 95, 73, 117, 194, 222, 114, 45, 5, 1, 146, 242, 125, 202, 174, 120, 4, 206, 235, 233, 212, 162, 33, 146, 193, 72, 224, 238, 73, 253, 179, 74, 87, 78, 4, 57, 176 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("05860de2-c04e-4de4-919f-1462c92fbf6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ecebdc81-b04e-4fda-acfd-15248cf3e325") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("05860de2-c04e-4de4-919f-1462c92fbf6a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ecebdc81-b04e-4fda-acfd-15248cf3e325"));

            migrationBuilder.AddColumn<DateTime>(
                name: "NotificationDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("e2a56d07-02d1-4ddd-8598-45953ae0906a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 22, 35, 94, 41, 61, 130, 241, 163, 108, 217, 80, 194, 28, 244, 237, 96, 152, 158, 248, 84, 197, 2, 216, 65, 63, 164, 99, 143, 101, 177, 129, 171, 172, 244, 150, 230, 134, 129, 36, 36, 58, 109, 217, 207, 186, 15, 0, 131, 223, 71, 74, 32, 63, 31, 171, 85, 229, 63, 194, 51, 245, 232, 229, 27 }, new byte[] { 187, 219, 49, 67, 108, 197, 163, 62, 241, 52, 146, 204, 87, 38, 152, 24, 175, 249, 86, 190, 161, 154, 241, 240, 244, 215, 137, 147, 32, 54, 46, 47, 191, 200, 192, 117, 51, 173, 50, 51, 11, 130, 192, 80, 172, 92, 90, 154, 156, 29, 72, 133, 127, 149, 22, 8, 15, 221, 36, 204, 238, 71, 249, 203, 229, 194, 54, 178, 246, 54, 54, 244, 54, 15, 112, 31, 82, 59, 253, 215, 187, 234, 99, 9, 46, 233, 230, 87, 219, 137, 35, 92, 156, 190, 139, 251, 40, 165, 133, 82, 175, 33, 118, 199, 61, 58, 12, 114, 136, 192, 221, 123, 8, 194, 142, 69, 5, 58, 28, 41, 197, 178, 64, 10, 119, 84, 125, 217 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3f24371f-6e9b-4418-9448-7d89baf639e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e2a56d07-02d1-4ddd-8598-45953ae0906a") });
        }
    }
}
