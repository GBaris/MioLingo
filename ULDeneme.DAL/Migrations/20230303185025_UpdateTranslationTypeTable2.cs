using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ULDeneme.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTranslationTypeTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KnownLangShort",
                table: "Translations",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnknownLangShort",
                table: "Translations",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KnownLangShort",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "UnknownLangShort",
                table: "Translations");
        }
    }
}
