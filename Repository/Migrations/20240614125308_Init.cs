using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additional_Service",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Service = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additional_Service", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Main_Service",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Service = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main_Service", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payment_Info = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status_Info = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Details",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Chek_in_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Eviction_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Prepayment = table.Column<bool>(type: "boolean", nullable: false),
                    Date_of_change = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentID = table.Column<long>(type: "bigint", nullable: false),
                    BookingID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Details_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Details_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Details_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Room_Name = table.Column<string>(type: "text", nullable: false),
                    BookingRoomID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Room_Booking_BookingRoomID",
                        column: x => x.BookingRoomID,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking_DetailsAdditional_Service",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Booking_DetailsID = table.Column<long>(type: "bigint", nullable: false),
                    Additional_ServiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_DetailsAdditional_Service", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_DetailsAdditional_Service_Additional_Service_Additi~",
                        column: x => x.Additional_ServiceID,
                        principalTable: "Additional_Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_DetailsAdditional_Service_Booking_Details_Booking_D~",
                        column: x => x.Booking_DetailsID,
                        principalTable: "Booking_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking_DetailsMain_Service",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Booking_DetailsID = table.Column<long>(type: "bigint", nullable: false),
                    Main_ServiceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_DetailsMain_Service", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_DetailsMain_Service_Booking_Details_Booking_Details~",
                        column: x => x.Booking_DetailsID,
                        principalTable: "Booking_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_DetailsMain_Service_Main_Service_Main_ServiceID",
                        column: x => x.Main_ServiceID,
                        principalTable: "Main_Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StatusID",
                table: "Booking",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_BookingID",
                table: "Booking_Details",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_PaymentID",
                table: "Booking_Details",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Details_UserID",
                table: "Booking_Details",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DetailsAdditional_Service_Additional_ServiceID",
                table: "Booking_DetailsAdditional_Service",
                column: "Additional_ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DetailsAdditional_Service_Booking_DetailsID",
                table: "Booking_DetailsAdditional_Service",
                column: "Booking_DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DetailsMain_Service_Booking_DetailsID",
                table: "Booking_DetailsMain_Service",
                column: "Booking_DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DetailsMain_Service_Main_ServiceID",
                table: "Booking_DetailsMain_Service",
                column: "Main_ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookingRoomID",
                table: "Room",
                column: "BookingRoomID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_DetailsAdditional_Service");

            migrationBuilder.DropTable(
                name: "Booking_DetailsMain_Service");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Additional_Service");

            migrationBuilder.DropTable(
                name: "Booking_Details");

            migrationBuilder.DropTable(
                name: "Main_Service");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
