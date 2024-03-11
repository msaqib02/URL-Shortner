using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace url_shortner.Migrations
{
    /// <inheritdoc />
    public partial class updatedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ShortUrls",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL")
                .Annotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Id",
                table: "ShortUrls",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
