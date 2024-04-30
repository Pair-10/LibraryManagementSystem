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
                keyValue: new Guid("91113a7d-9d84-453a-89d5-89451a9a5c5e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75301787-4a6e-4ccd-a56f-a8002863b69b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("8c3875b7-ff32-4f59-8916-ccd7a20808ae"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 137, 244, 114, 49, 235, 198, 204, 209, 196, 154, 195, 66, 175, 55, 102, 146, 62, 197, 137, 201, 217, 123, 242, 0, 58, 160, 9, 161, 132, 221, 236, 23, 31, 108, 242, 173, 107, 94, 40, 91, 221, 204, 9, 86, 11, 150, 94, 252, 58, 202, 122, 149, 115, 182, 127, 67, 120, 5, 206, 252, 59, 102, 164, 171 }, new byte[] { 59, 75, 186, 251, 64, 86, 197, 209, 252, 193, 8, 46, 96, 15, 181, 12, 181, 203, 82, 51, 215, 214, 150, 144, 124, 114, 185, 143, 130, 64, 6, 241, 47, 9, 240, 150, 64, 176, 164, 33, 175, 152, 221, 39, 54, 85, 122, 243, 159, 116, 167, 208, 183, 175, 33, 17, 63, 191, 26, 19, 235, 176, 35, 110, 136, 41, 65, 196, 218, 36, 151, 129, 196, 241, 92, 57, 222, 32, 16, 55, 232, 231, 184, 216, 14, 145, 131, 138, 121, 200, 76, 108, 145, 221, 199, 224, 49, 53, 236, 185, 152, 158, 32, 124, 196, 253, 229, 7, 15, 188, 223, 46, 124, 163, 205, 171, 50, 59, 57, 114, 170, 23, 40, 85, 205, 34, 132, 68 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("5991d714-f63c-4f8e-9d66-1546575b7a71"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8c3875b7-ff32-4f59-8916-ccd7a20808ae") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5991d714-f63c-4f8e-9d66-1546575b7a71"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c3875b7-ff32-4f59-8916-ccd7a20808ae"));

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
