using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Models
{
    public class Reservations
    {
        public int ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public int AccommodationId { get; set; }
        public int AmountOfExtraAdults { get; set; }
        public int AmountOfExtraChildren { get; set; }
        public int AmountOfExtraPets { get; set; }
        public double TotalCost { get; set; }
        public int PaymentStatus { get; set; }
        internal DbConnector Connector { get; set; }

        public Reservations(DbConnector connector)
        {
            Connector = connector;
        }

        public Reservations() { } //Necessary for deserialization

        public async Task InsertReservation()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = "INSERT INTO `reservations` (FirstName, LastName, Address, Email, Phone, ArrivalDate, DepartureDate, AmountOfExtraAdults, AmountOfExtraChildren, AmountOfExtraPets, TotalCost, PaymentStatus) " +
                                  "VALUES (@FirstName, @LastName, @Address, @Email, @Phone, @ArrivalDate, @DepartureDate, @AmountOfExtraAdults, @AmountOfExtraChildren, @AmountOfExtraPets, @TotalCost, @PaymentStatus)";
            AddReservationsParameters(command);
            await command.ExecuteNonQueryAsync();
            ReservationId = (int)command.LastInsertedId;
        }

        public async Task<Reservations> SelectReservationById(int id)
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `reservations` WHERE `ReservationId` = @ReservationId";
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@ReservationId",
                DbType = DbType.Int32,
                Value = id,
            });
            var res = await ReadAllReservations(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }

        public async Task<List<Reservations>> SelectAllReservations()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `reservations`";
            var res = await ReadAllReservations(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res : null;
        }

        public async Task UpdateReservationId()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"UPDATE `reservations` SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Email = @Email, Phone = @Phone, ArrivalDate = @ArrivalDate, DepartureDate = @DepartureDate, AmountOfExtraAdults = @AmountOfExtraAdults, AmountOfExtraChildren = @AmountOfExtraChildren, AmountOfExtraPets = @AmountOfExtraPets, TotalCost = @TotalCost, PaymentStatus = @PaymentStatus WHERE ReservationId = @ReservationId";
            AddReservationsParameters(command);
            AddReservationsId(command);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteReservationById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"DELETE FROM `reservations` WHERE ReservationId = @ReservationId";
            AddReservationsId(command);
            await command.ExecuteNonQueryAsync();
        }

        private void AddReservationsParameters(MySqlCommand command)
        {

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"FirstName",
                DbType = DbType.String,
                Value = FirstName
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"LastName",
                DbType = DbType.String,
                Value = LastName
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Address",
                DbType = DbType.String,
                Value = Address
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Email",
                DbType = DbType.String,
                Value = Email
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Phone",
                DbType = DbType.Int32,
                Value = Phone
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"ArrivalDate",
                DbType = DbType.String,
                Value = ArrivalDate
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"DepartureDate",
                DbType = DbType.String,
                Value = DepartureDate
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AccommodationId",
                DbType = DbType.Int32,
                Value = AccommodationId
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AmountOfExtraAdults",
                DbType = DbType.Int32,
                Value = AmountOfExtraAdults
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AmountOfExtraChildren",
                DbType = DbType.Int32,
                Value = AmountOfExtraChildren
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AmountOfExtraPets",
                DbType = DbType.Int32,
                Value = AmountOfExtraPets
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"TotalCost",
                DbType = DbType.Double,
                Value = TotalCost
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"PaymentStatus",
                DbType = DbType.Int32,
                Value = PaymentStatus
            });
        }

        private void AddReservationsId(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"ReservationId",
                DbType = DbType.Int32,
                Value = ReservationId
            });
        }

        private async Task<List<Reservations>> ReadAllReservations(DbDataReader reader)
        {
            var reservations = new List<Reservations>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var reservation = new Reservations(Connector)
                    {
                        ReservationId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Address = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetInt32(5),
                        ArrivalDate = reader.GetString(6),
                        DepartureDate = reader.GetString(7),
                        AccommodationId = reader.GetInt32(8),
                        AmountOfExtraAdults = reader.GetInt32(9),
                        AmountOfExtraChildren = reader.GetInt32(10),
                        AmountOfExtraPets = reader.GetInt32(11),
                        TotalCost = reader.GetDouble(12),
                        PaymentStatus = reader.GetInt32(13)
                    };
                    reservations.Add(reservation);
                }
            }

            return reservations;
        }
    }
}
