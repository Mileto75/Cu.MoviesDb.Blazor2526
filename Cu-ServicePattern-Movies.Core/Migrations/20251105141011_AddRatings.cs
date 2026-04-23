using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cu_ServicePattern_Movies.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Review", "Score", "UserId" },
                values: new object[,]
                {
                    { 5, 3, "Very good!!", 9, 1 },
                    { 6, 4, "good!!", 8, 2 },
                    { 7, 3, "Ok", 6, 2 },
                    { 8, 4, "Average..", 5, 1 },
                    { 9, 5, "Very good!!", 9, 1 },
                    { 10, 6, "good!!", 8, 2 },
                    { 11, 3, "Ok", 6, 2 },
                    { 12, 5, "Average..", 5, 1 },
                    { 13, 6, "Very good!!", 9, 1 },
                    { 14, 7, "good!!", 8, 2 },
                    { 15, 8, "Ok", 6, 2 },
                    { 16, 7, "Average..", 5, 1 },
                    { 17, 8, "Very good!!", 9, 1 },
                    { 18, 9, "good!!", 8, 2 },
                    { 19, 10, "Ok", 6, 2 },
                    { 20, 9, "Average..", 5, 1 },
                    { 21, 10, "Average..", 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
