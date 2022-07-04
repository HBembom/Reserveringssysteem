using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Models
{
    public class Accommodations
    {
        public int AccommodationId { get; set; }
        public double Price { get; set; }
        public string AccommodationType { get; set; }
        internal DbConnector Connector { get; set; }

        public Accommodations(DbConnector connector)
        {
            Connector = connector;
        }
        public Accommodations() { } //Necessary for deserialization

        public async Task InsertAccommodation()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = "INSERT INTO `accommodations` (AccommodationType, Price) VALUES (@AccommodationType, @Price)";
            AddAccommodationsParameters(command);
            await command.ExecuteNonQueryAsync();
            AccommodationId = (int)command.LastInsertedId;
        }

        public async Task<Accommodations> SelectAccommodationById(int id)
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `accommodations` WHERE `AccommodationId` = @AccommodationId";
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@AccommodationId",
                DbType = DbType.Int32,
                Value = id,
            });
            var res = await ReadAllAccommodationsAsync(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }

        public async Task<List<Accommodations>> SelectAllAccommodations()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `accommodations`";
            var res = await ReadAllAccommodationsAsync(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res : null;
        }

        public async Task UpdateAccommodationById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"UPDATE `accommodations` SET AccommodationType = @AccommodationType WHERE AccommodationId = @AccommodationId";
            AddAccommodationsParameters(command);
            AddAccommodationsId(command);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAccommodationById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"DELETE FROM `accommodations` WHERE AccommodationId = @AccommodationId";
            AddAccommodationsId(command);
            await command.ExecuteNonQueryAsync();
        }

        private void AddAccommodationsParameters(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AccommodationType",
                DbType = DbType.String,
                Value = AccommodationType
            });

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Price",
                DbType = DbType.Double,
                Value = Price
            });
        }
        private void AddAccommodationsId(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AccommodationId",
                DbType = DbType.Int32,
                Value = AccommodationId
            });
        }

        private async Task<List<Accommodations>> ReadAllAccommodationsAsync(DbDataReader reader)
        {
            var accommodations = new List<Accommodations>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var accommodation = new Accommodations(Connector)
                    {
                        AccommodationId = reader.GetInt32(0),
                        Price = reader.GetDouble(1),
                        AccommodationType = reader.GetString(2)
                    };
                    accommodations.Add(accommodation);
                }
            }

            return accommodations;
        }
    }
}
