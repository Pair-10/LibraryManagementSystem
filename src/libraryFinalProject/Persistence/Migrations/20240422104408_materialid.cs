using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class materialid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8f1bb940-fc9d-45ac-bea0-299299914f3c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d09d06ee-7ff5-4312-af2b-bdb3fbaf693f"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Magazines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("52bbdc78-7055-465b-b2d3-ef81efae4422"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 74, 209, 240, 186, 62, 85, 216, 28, 159, 157, 58, 29, 38, 52, 229, 44, 170, 239, 9, 100, 241, 186, 35, 204, 39, 165, 103, 150, 74, 9, 218, 73, 229, 156, 21, 168, 194, 251, 140, 58, 141, 215, 239, 247, 152, 9, 212, 194, 165, 193, 96, 118, 2, 236, 120, 50, 157, 70, 73, 232, 121, 225, 113, 81 }, new byte[] { 38, 127, 187, 238, 36, 81, 126, 214, 151, 5, 211, 189, 120, 26, 27, 206, 30, 116, 205, 47, 100, 67, 113, 162, 237, 167, 206, 220, 110, 14, 224, 208, 228, 168, 46, 197, 175, 74, 178, 145, 72, 120, 150, 136, 45, 130, 157, 204, 61, 74, 83, 135, 56, 10, 41, 251, 68, 122, 172, 193, 188, 18, 3, 163, 104, 204, 166, 175, 240, 74, 177, 36, 124, 42, 63, 21, 94, 134, 96, 201, 18, 66, 157, 195, 230, 9, 67, 81, 169, 196, 151, 176, 3, 36, 114, 33, 89, 119, 107, 93, 180, 66, 83, 214, 80, 210, 218, 95, 184, 132, 175, 184, 255, 123, 63, 197, 198, 221, 141, 250, 139, 174, 9, 114, 141, 91, 184, 132 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e184147e-3743-43da-a5da-f266f5a76d8c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("52bbdc78-7055-465b-b2d3-ef81efae4422") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e184147e-3743-43da-a5da-f266f5a76d8c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52bbdc78-7055-465b-b2d3-ef81efae4422"));

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("d09d06ee-7ff5-4312-af2b-bdb3fbaf693f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 129, 249, 227, 64, 209, 240, 204, 228, 205, 104, 179, 40, 25, 162, 73, 243, 131, 78, 104, 20, 75, 213, 254, 107, 27, 204, 65, 232, 59, 35, 179, 101, 11, 8, 145, 236, 170, 160, 39, 212, 97, 14, 61, 65, 31, 178, 70, 137, 133, 241, 231, 184, 192, 205, 115, 163, 18, 224, 164, 144, 122, 247, 158, 57 }, new byte[] { 245, 84, 49, 127, 154, 246, 209, 50, 190, 9, 2, 219, 141, 23, 193, 29, 52, 200, 236, 228, 88, 237, 175, 214, 37, 207, 178, 47, 255, 156, 103, 104, 40, 244, 110, 237, 130, 248, 11, 39, 202, 81, 78, 16, 83, 61, 66, 109, 68, 248, 236, 44, 243, 82, 70, 128, 95, 117, 76, 165, 104, 181, 103, 33, 58, 129, 151, 112, 48, 43, 43, 146, 124, 129, 228, 91, 191, 134, 222, 12, 209, 42, 185, 164, 194, 6, 129, 231, 114, 147, 200, 133, 36, 36, 99, 53, 201, 68, 33, 162, 213, 106, 220, 163, 76, 13, 215, 108, 185, 224, 180, 169, 129, 244, 173, 200, 179, 78, 58, 198, 194, 124, 29, 193, 236, 17, 116, 47 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8f1bb940-fc9d-45ac-bea0-299299914f3c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d09d06ee-7ff5-4312-af2b-bdb3fbaf693f") });
        }
    }
}
