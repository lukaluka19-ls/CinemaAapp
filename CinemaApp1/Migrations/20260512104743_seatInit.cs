using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaApp1.Migrations
{
    /// <inheritdoc />
    public partial class seatInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Seats_SeatId",
                table: "ReservationSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationSeats",
                table: "ReservationSeats");

            migrationBuilder.DropIndex(
                name: "IX_ReservationSeats_ReservationId",
                table: "ReservationSeats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationSeats");

            migrationBuilder.RenameTable(
                name: "ReservationSeats",
                newName: "ReservationSeat");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "ReservationSeat",
                newName: "SeatsId");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "ReservationSeat",
                newName: "ReservationsId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_SeatId",
                table: "ReservationSeat",
                newName: "IX_ReservationSeat_SeatsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationSeat",
                table: "ReservationSeat",
                columns: new[] { "ReservationsId", "SeatsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeat_Reservations_ReservationsId",
                table: "ReservationSeat",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeat_Seats_SeatsId",
                table: "ReservationSeat",
                column: "SeatsId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeat_Reservations_ReservationsId",
                table: "ReservationSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeat_Seats_SeatsId",
                table: "ReservationSeat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationSeat",
                table: "ReservationSeat");

            migrationBuilder.RenameTable(
                name: "ReservationSeat",
                newName: "ReservationSeats");

            migrationBuilder.RenameColumn(
                name: "SeatsId",
                table: "ReservationSeats",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "ReservationsId",
                table: "ReservationSeats",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeat_SeatsId",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_SeatId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReservationSeats",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationSeats",
                table: "ReservationSeats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSeats_ReservationId",
                table: "ReservationSeats",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Seats_SeatId",
                table: "ReservationSeats",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
