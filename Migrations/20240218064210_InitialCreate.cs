using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryModelling.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorBirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AuthorCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuthorPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BookFirstTimeOfPublication = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LibraryAdressCity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LibraryAdressDistrict = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LibraryAdressPostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LibraryAdressDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LibraryPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LibraryStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.LibraryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserTcIdentityNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    UserBirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserAdressCity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserAdressDistrict = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserAdressPostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UserAdressDetail = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserEMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookStores",
                columns: table => new
                {
                    BookStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookEditionNumber = table.Column<long>(type: "bigint", nullable: true),
                    BookPublishingHouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BookPageNumber = table.Column<int>(type: "int", nullable: true),
                    BookPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStores", x => x.BookStoreId);
                    table.ForeignKey(
                        name: "FK_BookStores_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorCategory",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorCategory", x => new { x.AuthorId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_AuthorCategory_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryUser",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryUser", x => new { x.LibraryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LibraryUser_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "LibraryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBookStore",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false),
                    BookStoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBookStore", x => new { x.LibraryId, x.BookStoreId });
                    table.ForeignKey(
                        name: "FK_LibraryBookStore_BookStores_BookStoreId",
                        column: x => x.BookStoreId,
                        principalTable: "BookStores",
                        principalColumn: "BookStoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryBookStore_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "LibraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookStore",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookStoreId = table.Column<int>(type: "int", nullable: false),
                    BookReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookDeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookStore", x => new { x.BookStoreId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBookStore_BookStores_BookStoreId",
                        column: x => x.BookStoreId,
                        principalTable: "BookStores",
                        principalColumn: "BookStoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookStore_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorCategory_CategoryId",
                table: "AuthorCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_BookId",
                table: "BookStores",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBookStore_BookStoreId",
                table: "LibraryBookStore",
                column: "BookStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryUser_UserId",
                table: "LibraryUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookStore_UserId",
                table: "UserBookStore",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorCategory");

            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "LibraryBookStore");

            migrationBuilder.DropTable(
                name: "LibraryUser");

            migrationBuilder.DropTable(
                name: "UserBookStore");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "BookStores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
