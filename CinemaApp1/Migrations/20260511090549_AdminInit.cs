using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp1.Migrations
{
    /// <inheritdoc />
    public partial class AdminInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "IsBlocked", "IsVerified", "Name", "PasswordHash", "ResetPasswordToken", "ResetPasswordTokenExpiry", "Role", "VerificationToken" },
                values: new object[] { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@cinemaapp.com", false, true, "Admin", "100000.tRxqU6dDAmCFYuEku/TZag==.Bb6Z/x+8cOATAmOT6T45bapxqb/ciIXDb0+J71McIjM=", null, null, 0, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
