using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterDAL.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Volonters");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Volonters",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Volonters",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Volonters");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Volonters");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Volonters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
