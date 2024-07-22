using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateNewSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "cleanarchitecture");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "cleanarchitecture");

            migrationBuilder.UpdateData(
                schema: "cleanarchitecture",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e1fe356-5ed5-4e46-b76e-214c960032da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f746e393-4ad1-4116-a4c6-1e7cdd3004cb", "AQAAAAIAAYagAAAAEElPmguXlzTZ41k74v4NhfYporiAVSBOzesx4y/IkXODrjRdA0gvgb3u64CxarfaAw==", "98394c54-dc3e-4df0-bc9d-4eb010a9b650" });

            migrationBuilder.UpdateData(
                schema: "cleanarchitecture",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bffc491-f117-4389-bc01-4a3403389fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "432985bd-881c-4e75-af75-0e3e040fa9e2", "AQAAAAIAAYagAAAAEMP0oeJa0ACjtAdTQCDxlZtM4prKu4QH1CrUUYw77/IjHy/2qUzHvkBhLTF9zuVwXg==", "72cb22bb-441a-42bf-9808-d0750f82facc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "cleanarchitecture",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "cleanarchitecture",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "cleanarchitecture",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "cleanarchitecture",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "cleanarchitecture",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "cleanarchitecture",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "cleanarchitecture",
                newName: "AspNetRoleClaims");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e1fe356-5ed5-4e46-b76e-214c960032da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eacef8e-c47c-4f3e-bf08-9e69b3827641", "AQAAAAIAAYagAAAAEPMJfuibA8aSnuhauB3gmSx8PXUElPhoIsUuut604JkOA2TJzbHLxO0TTb0WhROyZA==", "fdd1b24a-49ed-41a8-a897-94e1d4aa896d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bffc491-f117-4389-bc01-4a3403389fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68f52eb2-7b13-41fc-9198-6fcaa823f7ea", "AQAAAAIAAYagAAAAEOyCTvRcNXZpmmmf9oK8Cp1mWgT505ONKWk5zUHVeFd9jp56ttmWlshxIOnT7p3AeA==", "87b7b8f0-dd6d-48d5-8614-65ea5acab471" });
        }
    }
}
