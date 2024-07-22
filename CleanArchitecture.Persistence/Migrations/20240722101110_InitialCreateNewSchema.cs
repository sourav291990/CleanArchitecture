using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateNewSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cleanarchitecture",
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d988d063-7128-42b2-afa0-8010b8468388"));

            migrationBuilder.InsertData(
                schema: "cleanarchitecture",
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FirstName", "LastName", "PrimaryContactNumber", "SecondaryContactNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("c77ce20b-78e1-453d-8289-d88c88f97a5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "SampleUser", "SampleUser", 0L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cleanarchitecture",
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c77ce20b-78e1-453d-8289-d88c88f97a5d"));

            migrationBuilder.InsertData(
                schema: "cleanarchitecture",
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FirstName", "LastName", "PrimaryContactNumber", "SecondaryContactNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("d988d063-7128-42b2-afa0-8010b8468388"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "SampleUser", "SampleUser", 0L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
