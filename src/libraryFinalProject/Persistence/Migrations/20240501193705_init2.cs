using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("46611c8d-70b5-48d3-a12d-d2cddefcb69d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77df98c2-3681-4b6f-b2f6-8bf0d277d3a9"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Penalties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("898f363b-95f8-4f22-ade4-717cbe68711f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 128, 245, 245, 112, 56, 212, 160, 127, 13, 109, 120, 24, 134, 250, 255, 128, 82, 183, 251, 160, 110, 136, 249, 155, 67, 193, 75, 213, 60, 40, 230, 100, 151, 176, 66, 146, 26, 176, 59, 193, 25, 43, 158, 251, 141, 0, 18, 35, 167, 122, 66, 243, 49, 239, 239, 246, 16, 119, 246, 193, 14, 66, 228, 69 }, new byte[] { 143, 37, 92, 84, 188, 135, 185, 143, 242, 135, 83, 141, 46, 135, 117, 185, 212, 174, 139, 199, 162, 36, 229, 22, 87, 78, 169, 248, 7, 239, 212, 115, 156, 26, 95, 114, 61, 134, 183, 245, 12, 205, 5, 194, 34, 106, 89, 222, 81, 116, 235, 23, 235, 35, 8, 224, 142, 13, 169, 245, 64, 176, 244, 241, 67, 86, 63, 109, 134, 28, 251, 189, 103, 138, 183, 15, 131, 162, 191, 212, 45, 59, 3, 213, 209, 65, 188, 156, 74, 6, 118, 170, 94, 29, 83, 28, 178, 25, 99, 68, 227, 137, 75, 230, 146, 205, 209, 121, 222, 0, 79, 167, 181, 216, 126, 183, 158, 149, 162, 89, 216, 3, 126, 128, 224, 76, 66, 116 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0b338d31-bb7b-447a-82df-f4882a20a262"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("898f363b-95f8-4f22-ade4-717cbe68711f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0b338d31-bb7b-447a-82df-f4882a20a262"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("898f363b-95f8-4f22-ade4-717cbe68711f"));

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Penalties");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("77df98c2-3681-4b6f-b2f6-8bf0d277d3a9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 196, 123, 247, 187, 4, 55, 161, 103, 130, 213, 34, 69, 120, 116, 213, 93, 28, 24, 192, 172, 94, 68, 101, 182, 100, 251, 140, 60, 139, 214, 98, 98, 159, 73, 153, 27, 46, 182, 6, 38, 203, 92, 103, 220, 67, 83, 107, 18, 6, 60, 121, 214, 83, 49, 184, 106, 166, 59, 188, 243, 4, 113, 163, 38 }, new byte[] { 185, 170, 252, 193, 162, 14, 125, 90, 207, 69, 58, 207, 205, 239, 189, 164, 91, 140, 143, 98, 16, 208, 214, 111, 231, 226, 18, 35, 237, 219, 192, 199, 186, 98, 2, 56, 142, 31, 95, 101, 242, 204, 84, 193, 127, 10, 235, 44, 83, 141, 209, 128, 86, 184, 240, 194, 47, 229, 69, 210, 69, 15, 72, 171, 101, 100, 128, 102, 76, 215, 175, 241, 76, 26, 195, 0, 123, 160, 200, 223, 111, 50, 68, 21, 21, 132, 42, 15, 124, 52, 1, 248, 240, 67, 89, 126, 42, 105, 138, 112, 65, 224, 159, 75, 172, 33, 220, 190, 68, 25, 142, 255, 247, 173, 96, 243, 220, 46, 88, 134, 191, 21, 50, 164, 123, 126, 91, 75 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("46611c8d-70b5-48d3-a12d-d2cddefcb69d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("77df98c2-3681-4b6f-b2f6-8bf0d277d3a9") });
        }
    }
}
