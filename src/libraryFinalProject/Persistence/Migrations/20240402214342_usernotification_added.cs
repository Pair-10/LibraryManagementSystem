using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usernotification_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("90e20f1a-ff0e-4aa9-8190-dd913649c1ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be0b0161-b00a-4589-a6ad-f35b3b813858"));

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserNotifications.Admin", null },
                    { 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserNotifications.Read", null },
                    { 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserNotifications.Write", null },
                    { 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserNotifications.Create", null },
                    { 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserNotifications.Update", null },
                    { 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserNotifications.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("5fb698d5-d1fc-4df9-878b-c19d85bc0687"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 182, 63, 212, 59, 240, 38, 75, 143, 220, 123, 225, 150, 138, 49, 203, 84, 75, 231, 247, 216, 161, 204, 235, 100, 93, 124, 140, 220, 170, 108, 231, 111, 197, 86, 99, 212, 174, 115, 132, 47, 220, 69, 213, 121, 49, 63, 45, 115, 12, 83, 18, 207, 182, 71, 171, 156, 205, 131, 4, 49, 60, 70, 11, 30 }, new byte[] { 49, 102, 93, 254, 100, 90, 104, 9, 35, 121, 103, 218, 239, 18, 231, 34, 245, 215, 104, 25, 50, 148, 237, 240, 169, 163, 254, 233, 82, 50, 240, 86, 203, 183, 53, 40, 108, 234, 15, 46, 197, 95, 67, 10, 147, 11, 173, 28, 221, 100, 108, 196, 97, 48, 30, 36, 47, 48, 16, 168, 58, 132, 217, 43, 98, 134, 200, 126, 247, 82, 192, 38, 199, 124, 37, 10, 27, 56, 71, 212, 185, 62, 232, 32, 92, 9, 155, 37, 112, 163, 148, 216, 181, 33, 91, 100, 6, 180, 234, 14, 153, 132, 87, 143, 163, 28, 171, 200, 168, 85, 74, 133, 5, 190, 17, 117, 137, 127, 245, 156, 112, 32, 53, 241, 246, 73, 87, 112 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0443e004-6d22-4a94-9033-870f54beb643"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5fb698d5-d1fc-4df9-878b-c19d85bc0687") });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0443e004-6d22-4a94-9033-870f54beb643"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5fb698d5-d1fc-4df9-878b-c19d85bc0687"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PenaltyStatus", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new Guid("be0b0161-b00a-4589-a6ad-f35b3b813858"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 2, 4, 39, 120, 196, 39, 221, 247, 148, 21, 211, 25, 72, 251, 27, 58, 12, 92, 114, 113, 14, 76, 135, 118, 47, 251, 169, 177, 199, 97, 13, 204, 146, 197, 1, 178, 69, 107, 113, 142, 123, 108, 186, 245, 241, 156, 49, 253, 9, 63, 182, 203, 241, 62, 159, 121, 213, 105, 135, 146, 45, 116, 187, 8 }, new byte[] { 225, 8, 93, 204, 59, 150, 3, 184, 251, 38, 85, 18, 253, 121, 208, 224, 136, 90, 71, 154, 77, 167, 42, 200, 87, 214, 51, 121, 140, 145, 0, 103, 220, 192, 45, 99, 88, 159, 221, 35, 30, 255, 65, 111, 96, 137, 16, 95, 0, 12, 180, 196, 130, 124, 7, 0, 153, 118, 196, 196, 227, 197, 51, 11, 62, 168, 246, 71, 235, 64, 100, 198, 81, 125, 40, 25, 110, 184, 182, 249, 221, 31, 58, 198, 149, 167, 212, 28, 27, 103, 176, 47, 188, 71, 99, 220, 249, 30, 226, 168, 57, 51, 68, 2, 142, 189, 192, 81, 234, 14, 216, 245, 182, 146, 133, 219, 82, 165, 221, 198, 92, 128, 216, 117, 134, 55, 12, 180 }, null, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("90e20f1a-ff0e-4aa9-8190-dd913649c1ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("be0b0161-b00a-4589-a6ad-f35b3b813858") });
        }
    }
}
