using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTicketEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("543a336a-3f16-47c9-9834-831aeebbf497"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("565df62c-00cc-4fc1-b6d9-a3add42968de"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("66f80ee2-c1d2-432e-835a-7cfaf0369435"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1353fd1b-2b4b-47f2-931d-77c4c05c5601"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("71580f16-2ff2-4b0d-92bc-3c19c16f9f5f"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: false,
                defaultValue: "/images/no-photo-available.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldDefaultValue: "~/images/no-photo-available.jpg");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("286a2a4a-465b-42a3-b618-aa62b36c5e42"), "Sofia", "Cinema City" },
                    { new Guid("6c51dae6-ddf4-4e0a-91fc-cecb36fe530c"), "Varna", "Cinemax" },
                    { new Guid("6da4d928-f4ef-4f58-b5dc-3d67368d7ab8"), "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("769bca70-4b17-4c79-9f23-c54af5d202f1"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" },
                    { new Guid("b7b7fa6a-5811-48cd-8f5e-f906d5dc0e0c"), "Some description2", "Peter Jackson", 178, "Fantasy", new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Rings" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaId",
                table: "Tickets",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieId",
                table: "Tickets",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("286a2a4a-465b-42a3-b618-aa62b36c5e42"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6c51dae6-ddf4-4e0a-91fc-cecb36fe530c"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6da4d928-f4ef-4f58-b5dc-3d67368d7ab8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("769bca70-4b17-4c79-9f23-c54af5d202f1"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b7b7fa6a-5811-48cd-8f5e-f906d5dc0e0c"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: false,
                defaultValue: "~/images/no-photo-available.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldDefaultValue: "/images/no-photo-available.jpg");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("543a336a-3f16-47c9-9834-831aeebbf497"), "Sofia", "Cinema City" },
                    { new Guid("565df62c-00cc-4fc1-b6d9-a3add42968de"), "Varna", "Cinemax" },
                    { new Guid("66f80ee2-c1d2-432e-835a-7cfaf0369435"), "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1353fd1b-2b4b-47f2-931d-77c4c05c5601"), "Some description2", "Peter Jackson", 178, "Fantasy", new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Rings" },
                    { new Guid("71580f16-2ff2-4b0d-92bc-3c19c16f9f5f"), "Some description", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" }
                });
        }
    }
}
