using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using ReserveeringsSysteemApi.Controllers.Options;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Models
{
    public class Occupancies
    {
        public int OccupancyId { get; set; }
        public int AccommodationId { get; set; }
        public int ReservationId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int PaymentStatus { get; set; }
        internal DbConnector Connector { get; set; }

        public Occupancies(DbConnector connector)
        {
            Connector = connector;
        }

        public Occupancies() { } //Necessary for deserialization

        public async Task InsertOccupancy()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = "INSERT INTO `occupancies` (AccommodationId, ReservationId, ArrivalDate, DepartureDate, PaymentStatus) VALUES (@AccommodationId, @ReservationId, @ArrivalDate, @DepartureDate, @PaymentStatus)";
            AddOccupanciesParameters(command);
            await command.ExecuteNonQueryAsync();
            OccupancyId = (int)command.LastInsertedId;
        }

        public async Task<Occupancies> SelectOccupancyById(int id)
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `occupancies` WHERE `OccupancyId` = @OccupancyId";
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@OccupancyId",
                DbType = DbType.Int32,
                Value = id,
            });
            var res = await ReadAllOccupancies(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }

        public async Task<List<Occupancies>> SelectAllOccupancies(OccupancyOptions options)
        {
            await using var command = Connector.Conn.CreateCommand();

            if (options.StartDate != null && options.EndDate != null)
            {
                command.CommandText = @"SELECT * FROM `occupancies` WHERE `ArrivalDate` BETWEEN '" + options.StartDate + "' and '" + options.EndDate + "'";
            }
            else
            {
                command.CommandText = @"SELECT * FROM `occupancies`";

            }

            if (options.NewDateFirst)
            {
                command.CommandText += " ORDER BY `ArrivalDate` ASC";

            }
            var res = await ReadAllOccupancies(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res : null;
        }

        public async Task UpdateOccupancyById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"UPDATE `occupancies` SET `AccommodationId` = @AccommodationId, `ReservationId` = @ReservationId, `ArrivalDate` = @ArrivalDate, `DepartureDate` = @DepartureDate,  `PaymentStatus` = @PaymentStatus"
                                                               ;
            AddOccupanciesParameters(command);
            AddOccupanciesId(command);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteOccupancyById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"DELETE FROM `occupancies` WHERE OccupancyId = @OccupancyId";
            AddOccupanciesId(command);
            await command.ExecuteNonQueryAsync();
        }

        private void AddOccupanciesParameters(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AccommodationId",
                DbType = DbType.Int32,
                Value = AccommodationId
            });  
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"ReservationId",
                DbType = DbType.Date,
                Value = ReservationId
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"ArrivalDate",
                DbType = DbType.Date,
                Value = ArrivalDate
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"DepartureDate",
                DbType = DbType.String,
                Value = DepartureDate
            });command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"PaymentStatus",
                DbType = DbType.Int32,
                Value = PaymentStatus
            });
        }

        private void AddOccupanciesId(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"OccupancyId",
                DbType = DbType.Int32,
                Value = OccupancyId
            });
        }

        private async Task<List<Occupancies>> ReadAllOccupancies(DbDataReader reader)
        {
            var occupancies = new List<Occupancies>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var occupancy = new Occupancies(Connector)
                    {
                        OccupancyId = reader.GetInt32(0),
                        AccommodationId = reader.GetInt32(1),
                        ReservationId = reader.GetInt32(2),
                        ArrivalDate = reader.GetDateTime(3),
                        DepartureDate = reader.GetDateTime(4),
                        PaymentStatus = reader.GetInt32(5)
                    };
                    occupancies.Add(occupancy);
                }
            }

            return occupancies;
        }
    }
}
