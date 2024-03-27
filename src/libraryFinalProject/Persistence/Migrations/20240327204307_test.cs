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
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTypes_MaterialTypes_TypeId",
                table: "CategoryTypes");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a8e3a377-218d-47be-992c-5c3af4dd797d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d5dd65b-5a40-4d43-86af-e0ffe5c9e58e"));

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "CategoryTypes",
                newName: "MaterialTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTypes_TypeId",
                table: "CategoryTypes",
                newName: "IX_CategoryTypes_MaterialTypeId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("8cf0cea5-20b5-496b-a7f0-81005c4d77da"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 82, 102, 133, 131, 54, 178, 59, 100, 44, 220, 250, 153, 146, 230, 69, 27, 154, 80, 117, 183, 109, 189, 32, 248, 6, 73, 146, 173, 174, 113, 192, 230, 4, 126, 96, 10, 230, 86, 220, 187, 200, 127, 238, 136, 64, 104, 175, 190, 235, 221, 35, 84, 153, 92, 238, 70, 92, 54, 85, 235, 226, 42, 224, 184 }, new byte[] { 142, 161, 226, 214, 79, 84, 102, 237, 135, 185, 240, 57, 15, 32, 226, 170, 186, 179, 93, 218, 123, 0, 92, 43, 200, 245, 188, 100, 29, 116, 26, 144, 173, 227, 208, 21, 229, 230, 12, 201, 81, 173, 164, 115, 40, 182, 90, 79, 181, 105, 119, 188, 120, 111, 66, 138, 147, 185, 3, 65, 40, 217, 148, 64, 16, 187, 15, 87, 37, 13, 113, 227, 51, 136, 66, 130, 70, 218, 151, 176, 120, 208, 111, 70, 9, 140, 222, 184, 171, 204, 65, 183, 223, 142, 238, 121, 15, 180, 118, 112, 22, 84, 170, 82, 229, 220, 69, 5, 226, 209, 110, 87, 207, 171, 102, 120, 135, 252, 9, 227, 245, 43, 132, 194, 156, 74, 160, 96 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ebcb82f8-8065-41a8-b697-28b614a18248"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8cf0cea5-20b5-496b-a7f0-81005c4d77da") });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTypes_MaterialTypes_MaterialTypeId",
                table: "CategoryTypes",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTypes_MaterialTypes_MaterialTypeId",
                table: "CategoryTypes");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ebcb82f8-8065-41a8-b697-28b614a18248"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8cf0cea5-20b5-496b-a7f0-81005c4d77da"));

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "CategoryTypes",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTypes_MaterialTypeId",
                table: "CategoryTypes",
                newName: "IX_CategoryTypes_TypeId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("1d5dd65b-5a40-4d43-86af-e0ffe5c9e58e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 42, 223, 197, 13, 171, 206, 93, 75, 46, 181, 234, 214, 204, 240, 47, 70, 153, 178, 72, 124, 11, 23, 241, 112, 143, 169, 108, 160, 189, 223, 7, 226, 175, 126, 45, 183, 218, 123, 193, 100, 219, 253, 224, 221, 162, 196, 247, 24, 54, 128, 51, 141, 136, 130, 131, 174, 153, 254, 136, 100, 211, 116, 250, 39 }, new byte[] { 128, 163, 250, 182, 104, 55, 179, 187, 32, 149, 229, 207, 162, 61, 232, 156, 186, 226, 236, 180, 164, 249, 143, 254, 70, 78, 99, 105, 181, 67, 255, 95, 42, 157, 63, 207, 43, 9, 98, 195, 32, 8, 86, 234, 232, 128, 73, 235, 153, 191, 62, 159, 44, 236, 41, 30, 208, 144, 116, 158, 55, 81, 230, 172, 185, 68, 232, 96, 253, 244, 190, 36, 71, 209, 51, 161, 99, 197, 244, 196, 139, 14, 150, 100, 10, 168, 90, 169, 195, 62, 183, 180, 252, 193, 214, 128, 45, 125, 178, 162, 4, 23, 9, 189, 243, 186, 103, 240, 125, 174, 127, 62, 185, 91, 134, 177, 68, 35, 12, 243, 243, 56, 153, 222, 55, 218, 126, 81 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a8e3a377-218d-47be-992c-5c3af4dd797d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1d5dd65b-5a40-4d43-86af-e0ffe5c9e58e") });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTypes_MaterialTypes_TypeId",
                table: "CategoryTypes",
                column: "TypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
